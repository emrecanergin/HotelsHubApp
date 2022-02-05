using HotelsHubApp.Business.BusinessModels.HotelbedsModel.model;

namespace HotelsHubApp.Business.BusinessModels.HotelbedsModel.messages
{
    public class BookingRQ : AbstractGenericRequest
    {
        public Holder holder { get; set; }
        public List<BookingRoom> rooms { get; set; }
        public PaymentData paymentData { get; set; }
        public string clientReference { get; set; }
        public string remark { get; set; }

        public BookingRQ()
        {
            rooms = new List<BookingRoom>();
        }

    }
}
