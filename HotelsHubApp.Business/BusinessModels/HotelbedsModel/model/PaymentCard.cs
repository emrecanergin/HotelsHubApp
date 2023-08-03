using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsHubApp.Business.BusinessModels.HotelbedsModel.model
{
    public class PaymentCard
    {
        public string cardType { get; set; }
        public string cardNumber { get; set; }
        public string cardHolderName { get; set; }
        public string expiryDate { get; set; }
        public string cardCVC { get; set; }
    }
}
