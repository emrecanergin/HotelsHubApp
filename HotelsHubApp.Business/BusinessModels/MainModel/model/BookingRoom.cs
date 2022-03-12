using HotelsHubApp.Business.BusinessModels.MainModel.bookingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsHubApp.Business.BusinessModels.MainModel.model
{
    public class BookingRoom
    {
        public int RoomIndex { get; set; }
        public string RateKey { get; set; }
        public string RoomCode { get; set; }
        public string RoomName { get; set; }
        public IList<Pax> Paxes { get; set; }
    }
}
