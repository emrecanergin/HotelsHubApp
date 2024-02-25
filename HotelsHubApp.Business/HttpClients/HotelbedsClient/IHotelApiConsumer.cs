using HotelsHubApp.Business.BusinessModels.HotelbedsModel.messages;

namespace HotelsHubApp.Business.HttpClients.HotelbedsClient
{
    public interface IHotelApiConsumer
    {
        public Task<AvailabilityRS> GetAvailableHotels(AvailabilityRQ searchRequestBody);
        public Task<CheckRateRS> CheckRate(CheckRateRQ checkRateRequestBody);
        public Task<BookingRS> Book(BookingRQ bookingRequestBody);
    }
}
