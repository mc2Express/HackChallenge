using System.Collections.Generic;
using System.Linq;
using BusinessDomain;
using LinqToExcel;

namespace Infrastructure.Parse.Impl
{
    public class RelationInfoParser : IDocumentParser<RelationInfo>
    {
        public RelationInfo Parse(string documentPath)
        {
            var excel = new ExcelQueryFactory(documentPath) {ReadOnly = true};

            var relationInfo = new RelationInfo();

            relationInfo.LookupStatus = parseLookupStatus(excel);
            relationInfo.WerteGereiht = parserWerteGereiht(excel);
            relationInfo.WerteFreigegeben = parserWerteFreigegeben(excel);
            relationInfo.WerterKzub = parserWerteKzub(excel);
            relationInfo.WerteUbehVzweNr = parseWerteUbehVzweNr(excel);


            return relationInfo;
        }

        private IEnumerable<Werteliste> parserWerteFreigegeben(ExcelQueryFactory excel)
        {

            var result = from c in excel.Worksheet<Werteliste>("Werteliste Freigegeben")
                select c;

            return result.ToList();


        }

        private IEnumerable<LookupStatus> parseLookupStatus(ExcelQueryFactory excel)
        {

            var result = from c in excel.Worksheet<LookupStatus>("Lookup_STATUS")
                select c;

            return result.ToList();
        }

        private IEnumerable<Werteliste> parserWerteGereiht(ExcelQueryFactory excel)
        {

            var result = from c in excel.Worksheet<Werteliste>("Werteliste Gereiht")
                select c;

            return result.ToList();
        }

        private IEnumerable<Werteliste> parserWerteKzub(ExcelQueryFactory excel)
        {

            var result = from c in excel.Worksheet<Werteliste>("Werteliste KZUB")
                select c;

            return result.ToList();
        }

        private IEnumerable<Werteliste> parseWerteUbehVzweNr(ExcelQueryFactory excel)
        {

            var result = from c in excel.Worksheet<Werteliste>("Werteliste UBEH_VZWE_NR")
                select c;

            return result.ToList();
        }
    }
}