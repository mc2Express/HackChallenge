using System.Linq;
using Infrastructure.Parse.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExcelTests
{
    [TestClass]
    public class ExcelTest
    {
        [TestMethod]
        public void PurchaseContractImportTest()
        {
            var excelImporter = new PurchaseContractParser();
            var path =
                @"C:\Users\mathi\Desktop\ÖBB Hackathon 22. und 23.06.2017\2_Purchase contracts from supplier LugoTerminal\Incoming external purchase from supplier LugoT_excel.xlsx";
            var result = excelImporter.Parse(path);

            Assert.AreEqual(24, result.Count());
        }

        [TestMethod]
        public void ShuttleReservationImportHandlerTest()
        {
            var excelImporter = new ShuttleReservationParser();
            var path =
                @"C:\Users\mathi\Desktop\ÖBB Hackathon 22. und 23.06.2017\4_Reservation train lists for LugoShuttle\4_Train lists for Lugo Shuttle 2016  November_gekürzt.xls";
             var result = excelImporter.Parse(path);

            Assert.AreEqual(16, result.Count());
        }

        [TestMethod]
        public void IncomingInvoicesConfirmationsImportHandlerTest()
        {
            var excelImporter = new IncomingInvoicesConfirmationsImportHandler();
            var path =
                @"C:\Users\mathi\Desktop\ÖBB Hackathon 22. und 23.06.2017\6_Incoming external invoices from LugoTerminal\Incoming invoices_confirmation of supplier LugoTerminal_Excel.xlsx";
            var result = excelImporter.Parse(path);

            Assert.AreEqual(67, result.Count());

        }


        [TestMethod]
        public void WagonStatusImportHandlerTest()
        {
            var excelImporter = new WagonStatusParser();
            var path =
                @"C:\Users\mathi\Desktop\ÖBB Hackathon 22. und 23.06.2017\5_Wagon status message list\Wagen status message list_RTLM-548_Hackathon-Statusmeldungen_additional infos.xlsx";
            var result = excelImporter.Parse(path);

            Assert.AreEqual(2591, result.Count());

        }

        
        [TestMethod]
        public void RelationInfoParserTest()
        {
            var excelImporter = new RelationInfoParser();
            var path =
                @"C:\Users\mathi\Desktop\ÖBB Hackathon 22. und 23.06.2017\5_Wagon status message list\Wagen status message list_RTLM-548_Hackathon-Statusmeldungen_additional infos.xlsx";
            var result = excelImporter.Parse(path);

            var count = result.LookupStatus.Count();

        }
    }
}
