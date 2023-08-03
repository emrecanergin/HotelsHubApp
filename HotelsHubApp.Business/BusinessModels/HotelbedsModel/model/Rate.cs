using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsHubApp.Business.BusinessModels.HotelbedsModel.model
{
    public class Rate
    {
        public string rateKey { get; set; }
        public string rateClass { get; set; }
        public string rateType { get; set; }
        public decimal net { get; set; }
        public int allotment { get; set; }
        public string rateCommentsId { get; set; }
        public string paymentType { get; set; }
        public bool packaging { get; set; }
        public string boardCode { get; set; }
        public string boardName { get; set; }
        public IList<CancellationPolicy> cancellationPolicies { get; set; }
        public int rooms { get; set; }
        public int adults { get; set; }
        public int children { get; set; }
        public string childrenAges { get; set; }
        public IList<Promotion> promotions { get; set; }
        public string sellingRate { get; set; }
        public bool? hotelMandatory { get; set; }
        public Taxes taxes { get; set; }
        public IList<Offer> offers { get; set; }
    }
}
