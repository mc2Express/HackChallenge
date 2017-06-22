using System.Collections.Generic;

namespace BusinessDomain
{
    public class SupplyChain : IDomainObject
    {
        public IEnumerable<Contract> Contract { get; set; }
    }
}