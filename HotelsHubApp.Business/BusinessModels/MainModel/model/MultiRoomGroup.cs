using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.BusinessModel.MainModel.model
{
    public class MultiRoomGroup
    {
        public bool GroupRooms { get; set; }
        public bool SameRefundableNonRefundable { get; set; }
        public bool SameBoardMain { get; set; }
        public bool SameBoardSub { get; set; }
    }
}
