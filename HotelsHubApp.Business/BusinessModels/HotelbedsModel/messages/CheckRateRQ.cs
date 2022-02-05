using HotelsHubApp.Business.BusinessModels.HotelbedsModel.model;


namespace HotelsHubApp.Business.BusinessModels.HotelbedsModel.messages
{
    public class CheckRateRQ : AbstractGenericRequest
    {
        public bool upselling { get; set; }
        public List<BookingRoom> rooms { get; set; }
    }
}
