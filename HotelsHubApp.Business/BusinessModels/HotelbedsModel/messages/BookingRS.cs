using HotelsHubApp.Business.BusinessModels.HotelbedsModel.model;


namespace HotelsHubApp.Business.BusinessModels.HotelbedsModel.messages
{
    public class BookingRS : AbstractGenericResponse
    {
        public List<string> providerDetails { get; set; }
        public Booking booking { get; set; }
        public Source source { get; set; }
    }
}
