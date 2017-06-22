using LinqToExcel.Attributes;

namespace BusinessDomain
{
	public class WagonStatus
	{
		[ExcelColumn("TimestampID")]
		public string TimestampId { get; set; }

		[ExcelColumn("ZUGNR")]
		public string ZugNumber { get; set; }

		[ExcelColumn("ZUGDATUM")]
		public string Date { get; set; }

		[ExcelColumn("AKTVW")]
		public string LageBahnhofVerwaltung { get; set; }

		[ExcelColumn("AKTBHFNR")]
		public string LageBahnhofNumber { get; set; }

		[ExcelColumn("AKTDATUM")]
		public string LageZeitpunkt { get; set; }

		[ExcelColumn("STATUS_ID")]
		public string Status { get; set; }

		[ExcelColumn("PRZ")]
		public string PRZ { get; set; }

		[ExcelColumn("WAGENNR")]
		public string WAGENNR { get; set; }

		[ExcelColumn("HIST_LUD_TRNR")]
		public string GV_ID { get; set; }

		[ExcelColumn("HIST_UBEH_VZWE_NR")]
		public string Unterwegsbehandlungscode { get; set; }

		[ExcelColumn("STORNO")]
		public string Storno { get; set; }

		[ExcelColumn("EMPF")]
		public string Empfänger { get; set; }

		[ExcelColumn("LAST_MODIFIED")]
		public string LastModified { get; set; }

		[ExcelColumn("INSERTED")]
		public string S { get; set; }
	}
}