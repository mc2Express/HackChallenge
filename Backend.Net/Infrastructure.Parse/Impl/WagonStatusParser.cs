using System.Collections.Generic;
using System.Linq;
using BusinessDomain;
using LinqToExcel;

namespace Infrastructure.Parse.Impl
{
    public class WagonStatusParser : IDocumentParser<IEnumerable<WagonStatus>>
    {
        public IEnumerable<WagonStatus> Parse(string documentPath){
            var excel = new ExcelQueryFactory(documentPath) {ReadOnly = true};

            var result = from c in excel.Worksheet<WagonStatus>("Tabelle1")
                select c;

            return result.ToList();
        }
    }
}