using HotelsHubApp.Business.BusinessModels.MainModel.messages;
using HotelsHubApp.Core.Utilities.Results;

namespace HotelsHubApp.Business.Abstract.Hotelbeds.Services
{
    public interface ISearchService
    {
        Task<Result<SearchResponse>> HotelsResponse(SearchRequest searchRequest);    
    }
}
