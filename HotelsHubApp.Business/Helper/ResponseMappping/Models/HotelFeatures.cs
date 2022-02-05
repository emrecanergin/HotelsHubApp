using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsHubApp.Business.Helper.ResponseMappping.Models
{
    public class HotelFeatures
    {
        public int code { get; set; }
        public string name { get; set; }
        public string categoryName { get; set; }
        public string categoryCode { get; set; }
        public string currency { get; set; }
        public string destinationName { get; set; }
        public string destinationCode { get; set; }
        public short zoneCode { get; set; }
        public string zoneName { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double minRate { get; set; }
        public double maxRate { get; set; }
    }
}
