using System.Collections.Generic;
using System.Linq;
using BusinessDomain;
using LinqToExcel;

namespace Infrastructure.Parse.Impl
{
    public class ShuttleReservationParser : IDocumentParser<IEnumerable<ShuttleReservation>>
    {
        public IEnumerable<ShuttleReservation> Parse(string documentPath){
            var excel = new ExcelQueryFactory(documentPath) {ReadOnly = true};

            var results = new List<ShuttleReservation>();

            foreach (var worksheetName in excel.GetWorksheetNames())
            {
                var result = from trainNumber in excel.WorksheetRangeNoHeader("E3", "E3", worksheetName).First()
                    from receiveDate in excel.WorksheetRangeNoHeader("E6", "E6", worksheetName).First()
                    from sendDate in excel.WorksheetRangeNoHeader("E6", "E5", worksheetName).First()
                    from zulaufNachTarvisio in excel.WorksheetRangeNoHeader("E7", "E7", worksheetName).First()
                    select new ShuttleReservation
                    {
                        TrainNumber = trainNumber,
                        ReceiveDate = receiveDate,
                        SendDate = sendDate,
                        ZulaufNachTarvisio = zulaufNachTarvisio,
                        Items = excel.WorksheetRange<ShuttleReservationListItem>("A11", "AB512", worksheetName).ToList()
                    };
                results.AddRange(result);
            };

            return results;
        }
    }
}