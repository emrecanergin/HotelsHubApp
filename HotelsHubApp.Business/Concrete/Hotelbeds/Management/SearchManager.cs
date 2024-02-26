using HotelsHubApp.Business.Abstract.Hotelbeds.Requests;
using HotelsHubApp.Business.Abstract.Hotelbeds.Services;
using HotelsHubApp.Business.BusinessModels.HotelbedsModel.messages;
using HotelsHubApp.Business.BusinessModels.MainModel.messages;
using HotelsHubApp.Business.Concrete.Hotelbeds.Helper.Searching;
using HotelsHubApp.Business.Helper;
using HotelsHubApp.Business.ValidationRules.FluentValidation;
using HotelsHubApp.Core.Aspects.Autofac.Logging;
using HotelsHubApp.Core.Aspects.Autofac.Validation;
using HotelsHubApp.Core.RabbitMQClient.Abstract;
using HotelsHubApp.Core.RedisClient.Abstract;
using HotelsHubApp.Core.Utilities.Results;
using HotelsHubApp.DataAccess.Abstract;
using HotelsHubApp.Entities.EFCoreEntities;
using Serilog;
using System.Text.Json;


namespace HotelsHubApp.Business.Concrete.Hotelbeds.Management
{
    public class SearchManager : ISearchService
    {
        private readonly ISearchRequest  _searchRequest;
        private readonly IRedisService _redisService;
        private readonly IPublisherService _publisherService;
        private readonly IGetHotels _getHotels;
        private readonly ISearchRepository _searchRepository;


        public SearchManager(ISearchRequest hotelbedsRequest,
                             IRedisService redisService,                           
                             IPublisherService publisherService,
                             IGetHotels getHotels,
                             ISearchRepository searchRepository)
        {
            _redisService = redisService;
            _searchRequest = hotelbedsRequest;
            _publisherService = publisherService;
            _getHotels = getHotels; 
            _searchRepository = searchRepository;
        }

        [LogAspect]
        [ValidationAspect(typeof(SearchRequestValidator))]
        public async Task<Result<SearchResponse>> HotelsResponse(SearchRequest request)
        {
            var key = ComputeSHA256.ComputeSha256Hash(JsonSerializer.Serialize(request));
            SearchResponse searchResponse = new();

            if (!_redisService.Any(key))
            {
                var response = await _searchRequest.SearchInHotelbeds(request);
                searchResponse.Hotels = _getHotels.Get(response, request);
                //save as compressed response data
                _redisService.Add(key, JsonSerializer.Serialize(response),TimeSpan.FromMinutes(10));
            }
            else
            {
                var responseFromCache = _redisService.GetJsonData<AvailabilityRS>(key);
                searchResponse.Hotels = _getHotels.Get(responseFromCache, request);
            }
            _publisherService.SendData("responseLog", searchResponse);
         
            return new Result<SearchResponse>(searchResponse, "response created");
        }
    }
}