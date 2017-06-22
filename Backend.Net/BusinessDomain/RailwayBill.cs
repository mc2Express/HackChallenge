using System;
using System.Collections.Generic;

namespace BusinessDomain
{
    public sealed class RailwayBill : IDomainObject
    {
        public int ForwaringNumber { get; set; }

        // public int Evu { get; set; }

        public TrainStation ForwardingStation { get; set; }

        public TrainStation TakeOverStation { get; set; }

        public DateTime TakeOverDate { get; set; }

        public TrainStation ReceivingStation { get; set; }

        public DateTime IssueDate { get; set; }

        public string IssueLocation { get; set; }

        public IEnumerable<string> Descriptions { get; set; }

        public int ClassOfReservation { get; set; }

        public string ReservationNumber { get; set; }

        public Wagon Wagon { get; set; }
    }
}