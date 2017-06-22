using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LinqToExcel;
using WebApi.Models;

namespace WebApi.ExcelImport
{
    public class ShuttleReservationImportHandler
    {
        public ShuttleReservationImportHandler()
        {
        }

        public IList<ShuttleReservationDto> ImportShuttleReservations(string path){
            var excel = new ExcelQueryFactory(path);
            excel.ReadOnly = true;

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
                        Items = excel.WorksheetRange<ShuttleReservationListItemDto>("A11", "AB512", worksheetName)
                            .ToList()
                    };
                results.AddRange(result);
            };

            return results;

        }


    }
}