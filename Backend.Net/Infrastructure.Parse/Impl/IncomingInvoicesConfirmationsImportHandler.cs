using System.Collections.Generic;
using System.Linq;
using BusinessDomain;
using LinqToExcel;

namespace Infrastructure.Parse.Impl
{
    public class IncomingInvoicesConfirmationsImportHandler
    {
        public IList<IncomingInvoicesConfirmations> ImportIncomingInvoices(string path){
            var excel = new ExcelQueryFactory(path) {ReadOnly = true};

            var result = from c in excel.Worksheet<IncomingInvoicesConfirmations>(0)
                select c;

            return result.ToList().Where(x => x.InvoiceNb != null).ToList();
        }
    }
}