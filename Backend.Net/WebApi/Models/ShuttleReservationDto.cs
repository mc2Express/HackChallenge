using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class ShuttleReservationDto
    {
        
        public string TrainNumber { get; set; }

        public string SendDate { get; set; }
        public string ReceiveDate { get; set; }
        public string ZulaufNachTarvisio { get; set; }

        public IEnumerable<ShuttleReservationListItemDto> Items { get; set; }
    }
}