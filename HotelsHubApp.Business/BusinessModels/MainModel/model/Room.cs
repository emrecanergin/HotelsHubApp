using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Business.BusinessModel.MainModel.model
{

    public class Room
    {
        public int RoomIndex { get; set; }
        public IList<Pax>? Paxes { get; set; }
    }
}
