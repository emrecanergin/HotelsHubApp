using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsHubApp.Business.BusinessModels.MainModel.model
{
    public class RoomGroup
    {
        public IList<Rooms> Rooms { get; set; }
        public IList<Policy> Policies { get; set; }
        public RateKey RateKey { get; set; }
    }
}
