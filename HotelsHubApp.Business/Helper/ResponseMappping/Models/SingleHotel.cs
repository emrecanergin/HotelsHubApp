using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsHubApp.Business.Helper.ResponseMappping.Models
{
    public class SingleHotel
    {
        public HotelFeatures hotelFeatures { get; set; }
        public List<Room> rooms { get; set; }
    }

}
