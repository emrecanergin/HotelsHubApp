using HotelsHubApp.Business.BusinessModels.HotelbedsModel.messages;
using HotelsHubApp.Business.BusinessModels.MainModel.messages;

namespace HotelsHubApp.Business.Abstract.Requests.Hotelbeds
{
    public interface ISearchRequest
    {
        Task<AvailabilityRS> SearchInHotelbeds(SearchRequest request);
    }
}
