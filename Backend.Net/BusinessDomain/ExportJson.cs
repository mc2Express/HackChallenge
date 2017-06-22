using System.Collections.Generic;

namespace BusinessDomain
{
	public sealed class ExportJson
	{
		public Dictionary<string, ExportContract> contracts { get; set; }
	}
}