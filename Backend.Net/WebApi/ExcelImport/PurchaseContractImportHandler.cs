using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using LinqToExcel;
using WebApi.Models;

namespace WebApi.ExcelImport
{
    public class PurchaseContractImportHandler
    {
        public PurchaseContractImportHandler()
        {
        }

        public IList<PurchaseContractDto> ImportPurchaseContractExcel(string path){
            var excel = new ExcelQueryFactory(path);

            var result = from c in excel.Worksheet<PurchaseContractDto>(0)
                select c;

            return result.ToList();
        }


    }
}