using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LinqToExcel;
using WebApi.Models;

namespace WebApi.ExcelImport
{
    public class IncomingInvoicesConfirmationsImportHandler
    {
        public IncomingInvoicesConfirmationsImportHandler()
        {
        }

        public IList<IncomingInvoicesConfirmationsDto> ImportIncomingInvoices(string path){
            var excel = new ExcelQueryFactory(path);
            excel.ReadOnly = true;

            var result = from c in excel.Worksheet<IncomingInvoicesConfirmationsDto>(0)
                select c;

            return result.ToList().Where(x => x.InvoiceNb != null).ToList();
        }


    }
}