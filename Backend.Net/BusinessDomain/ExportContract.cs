using System.Collections.Generic;

namespace BusinessDomain
{
	public sealed class ExportContract
	{
		public string[] efbs { get; set; }

		public string[] invoices { get; set; }

		public Dictionary<string, string[]> wagons { get; set; }
	}
}