using System.Collections.Generic;
using System.Linq;
using BusinessDomain;
using LinqToExcel;

namespace Infrastructure.Parse.Impl
{
	public class PurchaseContractParser : IDocumentParser<IEnumerable<PurchaseContract>>
	{
		public IEnumerable<PurchaseContract> Parse(string documentPath)
		{
			var excel = new ExcelQueryFactory(documentPath) {ReadOnly = true};

			var result = from c in excel.Worksheet<PurchaseContract>(0)
				select c;

			return result.ToList();
		}
	}
}