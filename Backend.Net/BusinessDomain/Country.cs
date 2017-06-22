namespace BusinessDomain
{
    public sealed class Country : IDomainObject
    {
        public int CountryCode { get; set; }

        public string Name { get; set; }
    }
}