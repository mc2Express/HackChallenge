using System.Collections.Generic;

namespace BusinessDomain
{
	public sealed class Contract : IDomainObject
	{
		public string ContractNr { get; set; }

		public string SpContractDescription { get; set; }

		public string CreationDate { get; set; }

		public string OffertDate { get; set; }

		public string OffertNr { get; set; }

		public string OffertTextIntern { get; set; }

		public string OffertOrganisation { get; set; }

		public string SumWagen { get; set; }

		public string SumTonnen { get; set; }

		public IEnumerable<TransportClass> TransportClasses { get; set; }

		// referenced data; cannot be parsed
		public IList<RailwayBill> RailwayBills { get; set; }

		public IList<IncomingInvoicesConfirmations> Invoices { get; set; }

		public IList<Wagon> Wagons { get; set; }
	}
}