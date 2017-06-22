using LinqToExcel.Attributes;

namespace BusinessDomain
{
    public class ShuttleReservationListItemDto
    {

        [ExcelColumn("Fortl.Nr.")]
        public int Number { get; set; }

        [ExcelColumn("Waggon-Nr:")]
        public string WaggonNumber { get; set; }

        [ExcelColumn("NHM")]
        public string NHM { get; set; }

        [ExcelColumn("Gut / Merce")]
        public string Gut { get; set; }

        [ExcelColumn("VersandBhf. / staz. Partenza")]
        public string VersandBhf { get; set; }

        [ExcelColumn("Empfänger / Destinatario")]
        public string Empfaenger { get; set; }

        [ExcelColumn("Info")]
        public string Info { get; set; }

        [ExcelColumn("Ax")]
        public string Ax { get; set; }

        [ExcelColumn("Brutto")]
        public string Brutto { get; set; }

        [ExcelColumn("LüP")]
        public string LüP { get; set; }
        
        [ExcelColumn("Versanddatum")]
        public string Versanddatum { get; set; }
        
        [ExcelColumn("V - VW")]
        public string V_VW { get; set; }
        
        [ExcelColumn("V. Bhf. Nr")]
        public string BahnhofNumber { get; set; }

        [ExcelColumn("E - VW")]
        public string E_VW { get; set; }
        
        [ExcelColumn("E. Bhf. Nr")]
        public string E_BahnhofNumber { get; set; }

        [ExcelColumn("Versand-Nr.")]
        public string VersandNumber { get; set; }

        [ExcelColumn("Waggonnummer")]
        public string Waggonnummer { get; set; }

        [ExcelColumn("Tarifnummer")]
        public string Tarifnummer { get; set; }

        [ExcelColumn("Partner")]
        public string Partner { get; set; }

        [ExcelColumn("Netto-Gewicht d. Ladung")]
        public string Netto_Gewicht { get; set; }

        [ExcelColumn("Summe N-TO")]
        public string ASumme_NTO { get; set; }

        [ExcelColumn("Zug Abfahrt")]
        public string Zug_Abfahrt { get; set; }
        
        [ExcelColumn("Wg. leer retour")]
        public string WgLeerRetour { get; set; }
        
        [ExcelColumn("Aufenthalt in Std. TBV An - TBV Ab")]
        public string AufenthaldStunden { get; set; }
    }
}