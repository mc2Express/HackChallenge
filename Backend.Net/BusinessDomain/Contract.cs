using System.Collections.Generic;

namespace BusinessDomain
{
	public sealed class Contract : IDomainObject
	{
		public string ContractNr { get; set; }

		public string CreationDate { get; set; }

		public string OffertDate { get; set; }

		public string OffertNr { get; set; }

		public List<TransportClass> TransportClasses { get; set; }

		// recerenced data; cannot be parsed
		public List<RailwayBill> RailwayBills { get; set; }
	}
}