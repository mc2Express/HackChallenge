namespace BusinessDomain
{
	public sealed class Country : IDomainObject
	{
		public string CountryCode { get; set; }

		public string Name { get; set; }
	}
}