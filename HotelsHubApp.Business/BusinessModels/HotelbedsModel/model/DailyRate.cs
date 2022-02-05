using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsHubApp.Business.BusinessModels.HotelbedsModel.model
{
    public class DailyRate
    {
        public int offset { get; set; }
        public decimal dailyNet { get; set; }
        public decimal dailySellingRate { get; set; }
    }
}
