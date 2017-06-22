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
    public class WagonStatusImportHandler
    {
        public WagonStatusImportHandler()
        {
        }

        public IList<WagonStatusDto> ImportPurchaseContractExcel(string path){
            var excel = new ExcelQueryFactory(path);
            excel.ReadOnly = true;

            var result = from c in excel.Worksheet<WagonStatusDto>("Tabelle1")
                select c;

            return result.ToList();
        }


    }
}