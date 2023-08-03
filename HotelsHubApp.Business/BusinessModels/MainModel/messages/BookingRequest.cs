using HotelsHubApp.Business.BusinessModels.MainModel.model;

namespace HotelsHubApp.Business.BusinessModels.MainModel.messages
{
    public class BookingRequest
    {
        public Holder holder { get; set; }
        public List<BookingRequestRoom> rooms { get; set; }
        public CreditCard creditCard { get; set; }
        public string valuationToken { get; set; }
        public string clientReference { get; set; }
        public string remark { get; set; }
    }
}
