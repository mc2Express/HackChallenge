using LinqToExcel.Attributes;

namespace BusinessDomain
{
    public class IncomingInvoicesConfirmations
    {

        [ExcelColumn("Invoice nb")]
        public string InvoiceNb { get; set; }
        
        [ExcelColumn("date of invoice")]
        public string InvoiceDate { get; set; }

        [ExcelColumn("to")]
        public string To { get; set; }

        [ExcelColumn("charged service")]
        public string ChargedService { get; set; }

        [ExcelColumn("Wagon nb")]
        public string WagonNb { get; set; }

        [ExcelColumn("date of execution")]
        public string ExecutionDate { get; set; }

        [ExcelColumn("attached documents")]
        public string AttacedDocuments { get; set; }
    }
}