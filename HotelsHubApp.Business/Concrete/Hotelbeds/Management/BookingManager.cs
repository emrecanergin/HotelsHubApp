using HotelsHubApp.Business.Abstract.Hotelbeds.Services;
using HotelsHubApp.Business.BusinessModels.MainModel.messages;
using HotelsHubApp.Business.Concrete.Hotelbeds.Requests;
using HotelsHubApp.Core.Utilities.Results;

namespace HotelsHubApp.Business.Concrete.Hotelbeds.Management
{
    public class BookingManager : IBookingService
    {
        private readonly HotelbedsBookingRequest _hotelsBookingRequest;
        public BookingManager(HotelbedsBookingRequest hotelsBookingRequest)
        {
            _hotelsBookingRequest = hotelsBookingRequest;   
        }
        public async Task<Result<BookingResponse>> Book(BookingRequest request)
        {
            
            try
            {
                var res = await _hotelsBookingRequest.Book(request);
                BookingResponse response = new BookingResponse();
                response.ClientReference = res.booking.clientReference;
                return new Result<BookingResponse>(response, true);
            }
            catch (Exception ex)
            {
                return new Result<BookingResponse>(false, ex.Message);
            }
        }
    }
}
