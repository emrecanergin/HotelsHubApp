using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsHubApp.Business.BusinessModels.HotelbedsModel.model
{
    public class Rooms
    {
        public bool included { get; set; }
        public IList<string> room { get; set; }
    }
}

