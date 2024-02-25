using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsHubApp.Business.BusinessModels.HotelbedsModel.model
{
    public class Room
    {
        public string code { get; set; }
        public string name { get; set; }
        public IList<Rate> rates { get; set; }
    }
}
