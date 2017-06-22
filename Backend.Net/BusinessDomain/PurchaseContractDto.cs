using LinqToExcel.Attributes;

namespace BusinessDomain
{
    public class PurchaseContractDto
    {

            [ExcelColumn("purchase contract nb")]
        public string PurchaseContractNb { get; set; }

        [ExcelColumn(" date of purchase contract ")]
        public string DateOfPurchase { get; set; }

        [ExcelColumn("concerning route")]
        public string ConceringRoute { get; set; }

        [ExcelColumn("axle")]
        public string Axle { get; set; }

        [ExcelColumn("cargo")]
        public string Cargo { get; set; }

        [ExcelColumn("offered service")]
        public string OfferedService { get; set; }

        [ExcelColumn("additional information ")]
        public string AdditionalInfos { get; set; }

        [ExcelColumn("fee")]
        public string Fee { get; set; }

        [ExcelColumn("entity")]
        public string Entity { get; set; }
    }
}