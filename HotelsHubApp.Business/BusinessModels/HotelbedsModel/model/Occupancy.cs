using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsHubApp.Business.BusinessModels.HotelbedsModel.model
{
    public class Occupancy
    {
        public int rooms { get; set; }
        public int adults { get; set; }
        public int children { get; set; }
        public IList<Pax> paxes { get; set; }
    }
}
