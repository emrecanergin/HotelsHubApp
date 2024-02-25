using HotelsHubApp.Business.BusinessModels.HotelbedsModel.messages;
using HotelsHubApp.Business.HttpClients.HotelbedsClient;
using HotelsHubApp.Core.Utilities.HttpRequest;

namespace HotelsHubApp.Business.HttpRequests.Hotelbeds
{
    public class HotelApiConsumer : IHotelApiConsumer
    {
        private readonly IHttpRequestService<AvailabilityRS> _availability;
        private readonly IHttpRequestService<CheckRateRS> _checkrate;
        private readonly IHttpRequestService<BookingRS> _booking;

        const string checkrates = "hotel-api/1.0/checkrates";
        const string hotels = "hotel-api/1.0/hotels";
        const string bookings = "hotel-api/1.0/bookings";
        const string client_name = "HotelbedsRequest";

        public HotelApiConsumer(IHttpRequestService<AvailabilityRS> availability,
                                IHttpRequestService<CheckRateRS> checkrate,
                                IHttpRequestService<BookingRS> booking)
        {   
            
            _availability=availability; 
            _checkrate=checkrate;
            _booking=booking;   
        }

        public async Task<AvailabilityRS> GetAvailableHotels(AvailabilityRQ searchRequestBody)
        {
            return await _availability.PostRequestAsync(searchRequestBody,client_name, hotels);
            
        }

        public async Task<CheckRateRS> CheckRate(CheckRateRQ checkRateRequestBody)
        {
            return await _checkrate.PostRequestAsync(checkRateRequestBody,client_name, checkrates);

        }

        public async Task<BookingRS> Book(BookingRQ bookingRequestBody)
        {
            return await _booking.PostRequestAsync(bookingRequestBody,client_name, bookings);
        }
    }
}
