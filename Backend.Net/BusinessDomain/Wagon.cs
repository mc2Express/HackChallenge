using System.Collections.Generic;

namespace BusinessDomain
{
	public sealed class Wagon : IDomainObject
	{
		public string WagonNumber { get; set; }

		public string Info { get; set; }

		public string TotalWeight { get; set; }

		public Cargo Cargo { get; set; }

		public ShuttleReservationListItem Reservation { get; set; }

		public string ReservationTrainNumber { get; set; }

		public string ReservationSendDate { get; set; }

		public string ReservationReceiveDate { get; set; }

		public IList<WagonStatus> WagonStatus { get; set; }
	}
}