using HotelsHubApp.Business.Abstract.Hotelbeds.Requests;
using HotelsHubApp.Business.Abstract.Hotelbeds.Services;
using HotelsHubApp.Business.BusinessModels.MainModel.messages;
using HotelsHubApp.Core.Utilities.Results;

namespace HotelsHubApp.Business.Concrete.Hotelbeds.Management
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingRequest _bookingRequest;
        public BookingManager(IBookingRequest bookingRequest)
        {
            _bookingRequest = bookingRequest;
        }
        public async Task<Result<BookingResponse>> Book(BookingRequest request)
        {
            var res = await _bookingRequest.Book(request);
            BookingResponse response = new BookingResponse();
            response.ClientReference = res.booking.clientReference;
            return new Result<BookingResponse>(response);
        }
    }
}
