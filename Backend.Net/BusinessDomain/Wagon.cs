namespace BusinessDomain
{
    public sealed class Wagon : IDomainObject
    {
        public string WagonNumber { get; set; }

        public string Info { get; set; }

        public string TotalWeight { get; set; }

        public Cargo Cargo { get; set; }
    }
}