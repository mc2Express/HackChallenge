using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToExcel.Attributes;

namespace BusinessDomain
{
     public  class RelationInfo
    {

        public IEnumerable<LookupStatus> LookupStatus { get; set; }
        public IEnumerable<Werteliste> WerteGereiht { get; set; }
        public IEnumerable<Werteliste> WerteFreigegeben { get; set; }
        public IEnumerable<Werteliste> WerterKzub { get; set; }
        public IEnumerable<Werteliste> WerteUbehVzweNr { get; set; }
    }

    public class LookupStatus
    {
        [ExcelColumn("ID")]
        public string Id { get; set; }

        [ExcelColumn("STATUS")]
        public string Status { get; set; }
    }


    public class Werteliste
    {
        [ExcelColumn("Wert ")]
        public string Wert { get; set; }

        [ExcelColumn("Beschreibung")]
        public string Description { get; set; }
    }
}
