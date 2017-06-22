using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BusinessDomain;
using Infrastructure.Parse.Impl;
using Newtonsoft.Json;

namespace Infrastructure.Parse
{
	public class HackChallengeDataImporter
	{

	    public IEnumerable<Contract> GetHackChallangeData()
		{
			var contracts = new List<Contract>();
			var contractParser = new ContractParser();


		  
            var contractFiles = Directory.GetFiles(  Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@".\Data\Contracts"));
			foreach (var file in contractFiles)
			{
				contracts.Add(contractParser.Parse(file));
			}

			var railwayBills = new List<RailwayBill>();
			var railwayBillParser = new RailwayBillParser();
			var railwayBillFiles = Directory.GetFiles(  Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @".\Data\RailwayBills"));
			foreach (var file in railwayBillFiles)
			{
				railwayBills.AddRange(railwayBillParser.Parse(file));
			}

			var shuttleReservations = new List<ShuttleReservation>();
			var shuttleReservationParser = new ShuttleReservationParser();
			var shuttleReservationFiles = Directory.GetFiles(  Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@".\Data\ShuttleReservations"));
			foreach (var file in shuttleReservationFiles)
			{
				shuttleReservations.AddRange(shuttleReservationParser.Parse(file));
			}

			var wagonStatus = new List<WagonStatus>();
			var wagonStatusParser = new WagonStatusParser();
			var wagonStatusFiles = Directory.GetFiles(  Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@".\Data\WagonStatus"));
			foreach (var file in wagonStatusFiles)
			{
				wagonStatus.AddRange(wagonStatusParser.Parse(file));
			}

			var purchaseContracts = new List<PurchaseContract>();
			var purchaseContractParser = new PurchaseContractParser();
			var purchaseContractFiles = Directory.GetFiles(  Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@".\Data\PurchaseContracts"));
			foreach (var file in purchaseContractFiles)
			{
				purchaseContracts.AddRange(purchaseContractParser.Parse(file));
			}

			var invoices = new List<IncomingInvoicesConfirmations>();
			var invoiceParser = new IncomingInvoicesConfirmationsImportHandler();
			var invoiceFiles = Directory.GetFiles(  Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@".\Data\IncomingInvoicesConfirmations"));
			foreach (var file in invoiceFiles)
			{
				invoices.AddRange(invoiceParser.Parse(file));
			}

			RelationInfo relationInfos;
			var relationsParser = new RelationInfoParser();
			relationInfos =
				relationsParser.Parse(
					@"C:\Dev\HackChallenge\Backend.Net\Data\WagonStatus\Wagen status message list_RTLM-548_Hackathon-Statusmeldungen_additional infos.xlsx");

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
					if (
						contract.TransportClasses.Any(
							x => x.From.StationId == railwayBill.ForwardingStation.StationId
							     && x.To.StationId == railwayBill.ReceivingStation.StationId))
					{
						if (contract.RailwayBills == null) contract.RailwayBills = new List<RailwayBill>();
						contract.RailwayBills.Add(railwayBill);
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
					if (invoice?.WagonNb != null && contract.Wagons != null &&
					    contract.Wagons.Any(x => WagonMatches(x.WagonNumber, invoice.WagonNb)))
					{
						if (contract.Invoices == null) contract.Invoices = new List<IncomingInvoicesConfirmations>();
						contract.Invoices.Add(invoice);
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

						wagon.WagonStatus = wagonStatus.Where(x => WagonMatches11(x.WAGENNR, wagon.WagonNumber)).ToList();
					}
				}
			}

			//todo relationInfos

			var jsonFile = JsonConvert.SerializeObject(contracts);
			File.WriteAllText(@"C:\temp\fullJson.json", jsonFile);

			var outputJson = new ExportJson();
			outputJson.contracts = contracts.ToDictionary(x => x.ContractNr, x => new ExportContract
			{
				efbs = x.RailwayBills == null ? new string[] {} : x.RailwayBills?.Select(y => y.GvId).ToArray(),
				invoices = x.Invoices == null ? new string[] {} : x.Invoices?.Select(y => y.InvoiceNb).Distinct().ToArray(),
				wagons = x.Wagons == null
					? new Dictionary<string, string[]>()
					: x.Wagons?.ToDictionary(y => y.WagonNumber.Replace(" ", "").Replace("-", ""),
						y => y.WagonStatus.Where(z => z != null).Select(z => z.TimestampId).ToArray())
			});

			var exportJsonFile = JsonConvert.SerializeObject(outputJson);
			File.WriteAllText(@"C:\temp\jsonExport.json", exportJsonFile);


			return contracts;
		}

		private bool WagonMatches(string nr1, string nr2)
		{
			var nr11 = nr1?.Replace(" ", "")?.Replace("-", "");
			var nr22 = nr2?.Replace(" ", "")?.Replace("-", "");
			return nr11 != null && nr11 == nr22;
		}

		private bool WagonMatches11(string nr1, string nr2)
		{
			var nr11 = nr1?.Replace(" ", "")?.Replace("-", "")?.Substring(0, 11);
			var nr22 = nr2?.Replace(" ", "")?.Replace("-", "")?.Substring(0, 11);
			return nr11 != null && nr11 == nr22;
		}
	}
}