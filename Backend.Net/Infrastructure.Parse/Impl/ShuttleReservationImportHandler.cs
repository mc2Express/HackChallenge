using System.Collections.Generic;
using System.Linq;
using BusinessDomain;
using LinqToExcel;

namespace Infrastructure.Parse.Impl
{
    public class ShuttleReservationImportHandler
    {
        public IList<ShuttleReservationDto> ImportShuttleReservations(string path){
            var excel = new ExcelQueryFactory(path) {ReadOnly = true};

            var results = new List<ShuttleReservationDto>();

            foreach (var worksheetName in excel.GetWorksheetNames())
            {
                var result = from trainNumber in excel.WorksheetRangeNoHeader("E3", "E3", worksheetName).First()
                    from receiveDate in excel.WorksheetRangeNoHeader("E6", "E6", worksheetName).First()
                    from sendDate in excel.WorksheetRangeNoHeader("E6", "E5", worksheetName).First()
                    from zulaufNachTarvisio in excel.WorksheetRangeNoHeader("E7", "E7", worksheetName).First()
                    select new ShuttleReservationDto()
                    {
                        TrainNumber = trainNumber,
                        ReceiveDate = receiveDate,
                        SendDate = sendDate,
                        ZulaufNachTarvisio = zulaufNachTarvisio,
                        Items = Enumerable.ToList(excel.WorksheetRange<ShuttleReservationListItemDto>("A11", "AB512", worksheetName))
                    };
                results.AddRange(result);
            };

            return results;
        }
    }
}