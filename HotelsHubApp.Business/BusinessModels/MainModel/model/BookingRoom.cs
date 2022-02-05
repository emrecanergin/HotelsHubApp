using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessModel.MainModel.model
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
