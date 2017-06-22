using System.Collections.Generic;

namespace BusinessDomain
{
	public sealed class Contract : IDomainObject
	{
		public string ContractNr { get; set; }

		public string CreationDate { get; set; }

		public string OffertDate { get; set; }

		public string OffertNr { get; set; }

		public IEnumerable<TransportClass> TransportClasses { get; set; }

		// referenced data; cannot be parsed
		public IEnumerable<RailwayBill> RailwayBills { get; set; }

        public IEnumerable<IncomingInvoicesConfirmations> Invoices { get; set; }

        public IEnumerable<Wagon> Wagons { get; set; }
	}
}