using HotelsHubApp.Business.BusinessModels.HotelbedsModel.messages;
using HotelsHubApp.Business.BusinessModels.MainModel.messages;

namespace HotelsHubApp.Business.Abstract.Hotelbeds.Requests
{
    public interface ISearchRequest
    {
        Task<AvailabilityRS> SearchInHotelbeds(SearchRequest request);
    }
}
