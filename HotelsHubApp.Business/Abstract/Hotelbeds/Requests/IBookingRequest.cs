using HotelsHubApp.Business.BusinessModels.HotelbedsModel.messages;
using HotelsHubApp.Business.BusinessModels.MainModel.messages;

namespace HotelsHubApp.Business.Abstract.Hotelbeds.Requests
{
    internal interface IBookingRequest
    {
        public Task<BookingRS> Book(BookingRequest bookingRequest);
    }
}
