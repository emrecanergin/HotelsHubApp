using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.BusinessModel.MainModel.model
{
    public class Setting
    {
        public int TimeoutMs { get; set; }
        public string? Suppliers { get; set; }
        public bool OnRequest { get; set; }
        public object? B2B { get; set; }
        public string? Currency { get; set; }
        public DestinationCode? DestinationCode { get; set; }
        public IList<int>? HotelCodes { get; set; }
        public object? Markets { get; set; }
        public IList<Room>? Rooms { get; set; }
    }
}
