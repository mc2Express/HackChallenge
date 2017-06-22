using System.Collections.Generic;

namespace BusinessDomain
{
	public sealed class RailwayBill : IDomainObject
	{
		public string GvId { get; set; }

		public string ForwardingNumber { get; set; }

		// public int Evu { get; set; }

		public TrainStation ForwardingStation { get; set; }

		public TrainStation TakeOverStation { get; set; }

		public TrainStation ReceivingStation { get; set; }

		public TrainStation DeliveryStation { get; set; }

		public string TakeOverDate { get; set; }

		public string IssueDate { get; set; }

		public string IssueLocation { get; set; }

		public IEnumerable<string> Descriptions { get; set; }

		public string ClassOfReservation { get; set; }

		public string ReservationNumber { get; set; }

		public Wagon Wagon { get; set; }
	}
}