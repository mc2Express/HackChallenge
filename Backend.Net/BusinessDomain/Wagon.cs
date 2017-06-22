namespace BusinessDomain
{
    public sealed class Wagon : IDomainObject
    {
        public string WagonNumber { get; set; }

        public string Info { get; set; }

        public string TotalWeight { get; set; }

        public string SelfWeight { get; set; }

        public int NumberOfAxles { get; set; }

        public int MaxVelocity { get; set; }

        public Cargo Cargo { get; set; }
    }
}