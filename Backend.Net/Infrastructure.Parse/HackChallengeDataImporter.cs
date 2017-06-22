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
			var contractFiles = Directory.GetFiles(@"C:\Dev\HackChallenge\Backend.Net\Data\Contracts");
			foreach (var file in contractFiles)
			{
				contracts.Add(contractParser.Parse(file));
			}

			var railwayBills = new List<RailwayBill>();
			var railwayBillParser = new RailwayBillParser();
			var railwayBillFiles = Directory.GetFiles(@"C:\Dev\HackChallenge\Backend.Net\Data\RailwayBills");
			foreach (var file in railwayBillFiles)
			{
				railwayBills.AddRange(railwayBillParser.Parse(file));
			}

			var shuttleReservations = new List<ShuttleReservation>();
			var shuttleReservationParser = new ShuttleReservationParser();
			var shuttleReservationFiles = Directory.GetFiles(@"C:\Dev\HackChallenge\Backend.Net\Data\ShuttleReservations");
			foreach (var file in shuttleReservationFiles)
			{
				shuttleReservations.AddRange(shuttleReservationParser.Parse(file));
			}

			var wagonStatus = new List<WagonStatus>();
			var wagonStatusParser = new WagonStatusParser();
			var wagonStatusFiles = Directory.GetFiles(@"C:\Dev\HackChallenge\Backend.Net\Data\WagonStatus");
			foreach (var file in wagonStatusFiles)
			{
				wagonStatus.AddRange(wagonStatusParser.Parse(file));
			}

			var purchaseContracts = new List<PurchaseContract>();
			var purchaseContractParser = new PurchaseContractParser();
			var purchaseContractFiles = Directory.GetFiles(@"C:\Dev\HackChallenge\Backend.Net\Data\PurchaseContracts");
			foreach (var file in purchaseContractFiles)
			{
				purchaseContracts.AddRange(purchaseContractParser.Parse(file));
			}

			var invoices = new List<IncomingInvoicesConfirmations>();
			var invoiceParser = new IncomingInvoicesConfirmationsImportHandler();
			var invoiceFiles = Directory.GetFiles(@"C:\Dev\HackChallenge\Backend.Net\Data\IncomingInvoicesConfirmations");
			foreach (var file in invoiceFiles)
			{
				invoices.AddRange(invoiceParser.Parse(file));
			}

			return EnrichData(contracts, railwayBills, shuttleReservations, wagonStatus, purchaseContracts, invoices);
		}

		private IEnumerable<Contract> EnrichData(IEnumerable<Contract> contracts,
			IEnumerable<RailwayBill> railwayBills,
			IEnumerable<ShuttleReservation> shuttleReservations,
			IEnumerable<WagonStatus> wagonStatus,
			IEnumerable<PurchaseContract> purchaseContracts,
			IEnumerable<IncomingInvoicesConfirmations> invoices)
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


			return contracts;
		}

		private bool WagonMatches(string nr1, string nr2)
		{
			var nr11 = nr1?.Replace(" ", "")?.Replace("-", "");
			var nr22 = nr2?.Replace(" ", "")?.Replace("-", "");
			return nr11 != null && nr11 == nr22;
		}

		private bool WagonMatches11(string nr1, string nr2) {
			var nr11 = nr1?.Replace(" ", "")?.Replace("-", "")?.Substring(0,11);
			var nr22 = nr2?.Replace(" ", "")?.Replace("-", "")?.Substring(0,11);
			return nr11 != null && nr11 == nr22;
		}
	}
}