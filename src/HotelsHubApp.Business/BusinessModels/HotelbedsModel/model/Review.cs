using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsHubApp.Business.BusinessModels.HotelbedsModel.model
{
    public class Review
    {
        public decimal rate { get; set; }
        public int reviewCount { get; set; }
        public string type { get; set; }
    }
}
