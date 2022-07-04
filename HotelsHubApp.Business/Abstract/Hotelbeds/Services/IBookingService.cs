using HotelsHubApp.Business.BusinessModels.MainModel.messages;
using HotelsHubApp.Core.Utilities.Results;

namespace HotelsHubApp.Business.Abstract.Hotelbeds.Services
{
    public interface IBookingService
    {
        public Task<Result<BookingResponse>> Book(BookingRequest request);
    }
}
