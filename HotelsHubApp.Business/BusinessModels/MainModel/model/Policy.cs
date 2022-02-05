using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Business.BusinessModel.MainModel.model
{
    public class Policy
    {
        public decimal Price { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public MinimumSalePrice MinimumSalePrice { get; set; }
        public string Currency { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public byte PolicyType { get; set; }
    }
}
