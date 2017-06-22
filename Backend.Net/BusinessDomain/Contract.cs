using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessDomain
{
    public sealed class Contract : IDomainObject
    {
        public int ContractNr { get; set; }

        public DateTime ContractDate { get; set; }

        public TrainStation From { get; set; }

        public TrainStation Via { get; set; }

        public TrainStation To { get; set; }
    }
}
