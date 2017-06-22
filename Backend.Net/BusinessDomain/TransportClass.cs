using System.Collections.Generic;

namespace BusinessDomain
{
	public sealed class TransportClass : IDomainObject
	{
		public TrainStation From { get; set; }

		public TrainStation Via { get; set; }

		public TrainStation To { get; set; }

		public string SzVertragNr { get; set; }


		// cannot be parsed, must be found via some heuristic methods
		public List<RailwayBill> RailwayBills { get; set; }
	}
}