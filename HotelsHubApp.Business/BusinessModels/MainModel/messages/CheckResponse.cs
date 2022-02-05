using Business.BusinessModel.MainModel.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsHubApp.Business.BusinessModels.MainModel.messages
{
    public class CheckResponse 
    {
        public HotelCR hotel { get; set; }
        public IList<RoomCR> rooms { get; set; }
        public string ValuationId { get; set; }
        public decimal Price { get; set; }
        public double MinimumSellingPrice { get; set; }
        public bool CommissionPrice { get; set; }
        public bool Promotion { get; set; }
        public string Currency { get; set; }
        public IList<Policy> Policies { get; set; }
        public IList<PolicyRemark> PolicyRemarks { get; set; }
        public IList<TaxesAndFee> TaxesAndFees { get; set; }
        public string Remark { get; set; }
        public bool OnRequest { get; set; }
    }
}
