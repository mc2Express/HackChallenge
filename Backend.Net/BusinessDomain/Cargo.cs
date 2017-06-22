namespace BusinessDomain
{
    public sealed class Cargo : IDomainObject
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public string Weight { get; set; }
    }
}