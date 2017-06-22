using System.Collections.Generic;
using System.Linq;
using BusinessDomain;
using LinqToExcel;

namespace Infrastructure.Parse.Impl
{
    public class PurchaseContractImportHandler
    {
        public IList<PurchaseContractDto> ImportPurchaseContractExcel(string path){
            var excel = new ExcelQueryFactory(path) {ReadOnly = true};

            var result = from c in excel.Worksheet<PurchaseContractDto>(0)
                select c;

            return result.ToList();
        }
    }
}