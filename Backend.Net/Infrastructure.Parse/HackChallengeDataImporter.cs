using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BusinessDomain;
using Infrastructure.Parse.Impl;

namespace Infrastructure.Parse
{
	public class HackChallengeDataImporter
	{
		public IEnumerable<Contract> GetHackChallangeData()
		{
			var contracts = new List<Contract>();
			var contractParser = new ContractParser();

			var contractFiles = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @".\Data\Contracts"));
			foreach (var file in contractFiles)
			{
				contracts.Add(contractParser.Parse(file));
			}

			var railwayBills = new List<RailwayBill>();
			var railwayBillParser = new RailwayBillParser();
			var railwayBillFiles = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @".\Data\RailwayBills"));
			foreach (var file in railwayBillFiles)
			{
				railwayBills.AddRange(railwayBillParser.Parse(file));
			}

			var shuttleReservations = new List<ShuttleReservation>();
			var shuttleReservationParser = new ShuttleReservationParser();
			var shuttleReservationFiles =
				Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @".\Data\ShuttleReservations"));
			foreach (var file in shuttleReservationFiles)
			{
				shuttleReservations.AddRange(shuttleReservationParser.Parse(file));
			}

			var wagonStatus = new List<WagonStatus>();
			var wagonStatusParser = new WagonStatusParser();
			var wagonStatusFiles = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @".\Data\WagonStatus"));
			foreach (var file in wagonStatusFiles)
			{
				wagonStatus.AddRange(wagonStatusParser.Parse(file));
			}

			var purchaseContracts = new List<PurchaseContract>();
			var purchaseContractParser = new PurchaseContractParser();
			var purchaseContractFiles =
				Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @".\Data\PurchaseContracts"));
			foreach (var file in purchaseContractFiles)
			{
				purchaseContracts.AddRange(purchaseContractParser.Parse(file));
			}

			var invoices = new List<IncomingInvoicesConfirmations>();
			var invoiceParser = new IncomingInvoicesConfirmationsImportHandler();
			var invoiceFiles =
				Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @".\Data\IncomingInvoicesConfirmations"));
			foreach (var file in invoiceFiles)
			{
				invoices.AddRange(invoiceParser.Parse(file));
			}

			RelationInfo relationInfos = null;
			//var relationsParser = new RelationInfoParser();
			//relationInfos =
			//	relationsParser.Parse(
			//		@"C:\Dev\HackChallenge\Backend.Net\Data\WagonStatus\Wagen status message list_RTLM-548_Hackathon-Statusmeldungen_additional infos.xlsx");

			return EnrichData(contracts, railwayBills, shuttleReservations, wagonStatus, purchaseContracts, invoices,
				relationInfos);
		}

		private IEnumerable<Contract> EnrichData(IEnumerable<Contract> contracts,
			IEnumerable<RailwayBill> railwayBills,
			IEnumerable<ShuttleReservation> shuttleReservations,
			IEnumerable<WagonStatus> wagonStatus,
			IEnumerable<PurchaseContract> purchaseContracts,
			IEnumerable<IncomingInvoicesConfirmations> invoices,
			RelationInfo relationInfos)
		{
			// first, match the containing railwayBills to the contracts
			foreach (var railwayBill in railwayBills)
			{
				// find match by from/to/via
				foreach (var contract in contracts)
				{
					var matchingTransportClasses = contract.TransportClasses.Where(
						x => TrainStationMatches(x.From, railwayBill.ForwardingStation)
						     && TrainStationMatches(x.To, railwayBill.ReceivingStation)
						     || x.From?.Name != null &&
						     (StationNamesMatchLoosely(x.From.Name, railwayBill.OtherTransportWayDescFrom)
						      || StationNamesMatchLoosely(x.From.Name, railwayBill.OtherTransportWayDescTo)
						      || x.To?.Name != null && (
							      StationNamesMatchLoosely(x.To.Name, railwayBill.OtherTransportWayDescFrom)
							      || StationNamesMatchLoosely(x.To.Name, railwayBill.OtherTransportWayDescTo))));
					if (matchingTransportClasses.Any())
					{
						if (contract.RailwayBills == null) contract.RailwayBills = new List<RailwayBill>();
						contract.RailwayBills.Add(railwayBill);
						foreach (var mtc in matchingTransportClasses)
						{
							if (mtc.RailwayBills == null) mtc.RailwayBills = new List<RailwayBill>();
							mtc.RailwayBills.Add(railwayBill);
						}
						if (contract.Wagons == null) contract.Wagons = new List<Wagon>();
						if (railwayBill?.Wagon?.WagonNumber != null &&
						    contract.Wagons.All(x => !WagonMatches(x.WagonNumber, railwayBill.Wagon.WagonNumber)))
						{
							contract.Wagons.Add(railwayBill.Wagon);
						}
						break;
					}
				}
			}

			foreach (var contract in contracts)
			{
				foreach (var invoice in invoices)
				{
					if (invoice?.WagonNb != null && contract.Wagons != null)
					{
						var matchingWagons = contract.Wagons.Where(x => WagonMatches(x.WagonNumber, invoice.WagonNb));
						if (matchingWagons.Any())
						{
							if (contract.Invoices == null) contract.Invoices = new List<IncomingInvoicesConfirmations>();
							contract.Invoices.Add(invoice);
						}

						foreach (var wag in matchingWagons)
						{
							wag.Invoice = invoice;
						}
					}
				}

				if (contract.Wagons != null)
				{
					foreach (var wagon in contract.Wagons)
					{
						foreach (var shuttleReservation in shuttleReservations)
						{
							var match = shuttleReservation.Items.FirstOrDefault(x => WagonMatches(x.WaggonNumber, wagon.WagonNumber));
							if (match != null)
							{
								wagon.Reservation = match;
								wagon.ReservationTrainNumber = shuttleReservation.TrainNumber;
								wagon.ReservationSendDate = shuttleReservation.SendDate;
								wagon.ReservationReceiveDate = shuttleReservation.ReceiveDate;
								break;
							}
						}

						wagon.WagonStatus = wagonStatus.Where(x => WagonMatches(x.WAGENNR, wagon.WagonNumber)).ToList();
					}
				}
			}

			//todo relationInfos

			//var jsonFile = JsonConvert.SerializeObject(contracts);
			//File.WriteAllText(@"C:\temp\fullJson.json", jsonFile);

			//var outputJson = new ExportJson();
			//outputJson.contracts = contracts.ToDictionary(x => x.ContractNr, x => new ExportContract
			//{
			//	efbs = x.RailwayBills == null ? new string[] {} : x.RailwayBills?.Select(y => y.GvId).ToArray(),
			//	invoices = x.Invoices == null ? new string[] {} : x.Invoices?.Select(y => y.InvoiceNb).Distinct().ToArray(),
			//	wagons = x.Wagons == null
			//		? new Dictionary<string, string[]>()
			//		: x.Wagons?.ToDictionary(y => y.WagonNumber.Replace(" ", "").Replace("-", ""),
			//			y => y.WagonStatus.Where(z => z != null).Select(z => z.TimestampId).ToArray())
			//});

			//var exportJsonFile = JsonConvert.SerializeObject(outputJson);
			//File.WriteAllText(@"C:\temp\jsonExport.json", exportJsonFile);


			return contracts;
		}

		private bool WagonMatches(string nr1, string nr2)
		{
			var nr11 = nr1?.Replace(" ", "")?.Replace("-", "")?.Substring(0, 11);
			var nr22 = nr2?.Replace(" ", "")?.Replace("-", "")?.Substring(0, 11);
			return nr11 != null && nr11 == nr22;
		}

		private bool StationIdMatches(string id1, string id2)
		{
			return id1 != null && id1?.Substring(0, 5) == id2?.Substring(0, 5);
		}

		private bool TrainStationMatches(TrainStation station1, TrainStation station2)
		{
			return station1 != null &&
			       (StationIdMatches(station1.StationId, station2.StationId) ||
			        station1.Name != null && station1.Name.Equals(station2.Name, StringComparison.InvariantCultureIgnoreCase));
		}

		private bool StationNamesMatchLoosely(string str1, string str2)
		{
			if (str1 == null) return false;
			return str1.Equals(str2, StringComparison.InvariantCultureIgnoreCase);

			//if (str1.Length <= 8) return str1.Equals(str2, StringComparison.InvariantCultureIgnoreCase);
			//if (str2 == null || str2.Length <= 8) return false;
			//return str1.Substring(0, 8).Equals(str2?.Substring(0, 8), StringComparison.InvariantCultureIgnoreCase);
		}
	}
}