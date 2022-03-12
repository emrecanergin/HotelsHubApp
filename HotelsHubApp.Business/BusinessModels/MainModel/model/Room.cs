using HotelsHubApp.Business.BusinessModels.MainModel.bookingModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsHubApp.Business.BusinessModels.MainModel.model
{

    public class Room
    {
        public int RoomIndex { get; set; }
        public IList<Pax>? Paxes { get; set; }
    }
}
