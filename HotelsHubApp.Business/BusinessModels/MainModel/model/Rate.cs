using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsHubApp.Business.BusinessModels.MainModel.model
{
    public class Rate
    {
        public decimal price { get; set; }
        public string MinimumSellingPrice { get; set; }
        public string Currency { get; set; }
        public string boardCode { get; set; }
        public string boardName { get; set; }
        public int rooms { get; set; }
        public int adults { get; set; }
        public int children { get; set; }
        public string amount { get; set; }
    }
}
