using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.ExcelImport;

namespace ExcelTests
{
    [TestClass]
    public class ExcelTest
    {
        [TestMethod]
        public void PurchaseContractImportTest()
        {
            var excelImporter = new PurchaseContractImportHandler();
            var path =
                @"C:\Users\mathi\Desktop\ÖBB Hackathon 22. und 23.06.2017\2_Purchase contracts from supplier LugoTerminal\Incoming external purchase from supplier LugoT_excel.xlsx";
            var result = excelImporter.ImportPurchaseContractExcel(path);

            Assert.AreEqual(24, result.Count);

        }

        [TestMethod]
        public void ShuttleReservationImportHandlerTest()
        {
            var excelImporter = new ShuttleReservationImportHandler();
            var path =
                @"C:\Users\mathi\Desktop\ÖBB Hackathon 22. und 23.06.2017\4_Reservation train lists for LugoShuttle\4_Train lists for Lugo Shuttle 2016  November_gekürzt.xls";
             var result = excelImporter.ImportShuttleReservations(path);

            Assert.AreEqual(16, result.Count);

        }
    }
}
