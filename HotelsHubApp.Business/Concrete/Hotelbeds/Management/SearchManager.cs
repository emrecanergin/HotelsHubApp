using AutoMapper;
using HotelsHubApp.Business.Abstract.Hotelbeds.Requests;
using HotelsHubApp.Business.Abstract.Hotelbeds.Services;
using HotelsHubApp.Business.BusinessModels.HotelbedsModel.messages;
using HotelsHubApp.Business.BusinessModels.MainModel.messages;
using HotelsHubApp.Business.BusinessModels.MainModel.model;
using HotelsHubApp.Business.Helper;
using HotelsHubApp.Business.Helper.ResponseMappping;
using HotelsHubApp.Business.ValidationRules.FluentValidation;
using HotelsHubApp.Core.Aspects.Autofac.Logging;
using HotelsHubApp.Core.Aspects.Autofac.Validation;
using HotelsHubApp.Core.RabbitMQClient.Abstract;
using HotelsHubApp.Core.RedisClient.Abstract;
using HotelsHubApp.Core.Utilities.Results;
using System.Text.Json;


namespace HotelsHubApp.Business.Concrete.Hotelbeds.Management
{
    public class SearchManager : ISearchService
    {
        private readonly ISearchRequest  _searchRequest;
        private readonly IRedisService _redisService;
        private readonly IResponseMap _responseMap;
        private readonly IPublisherService _publisherService;
        private readonly IMapper _mapper;



        public SearchManager(ISearchRequest hotelbedsRequest,
                             IRedisService redisService,
                             IResponseMap responseMapping,
                             IPublisherService publisherService,
                             IMapper mapper
                             )
        {
            _redisService = redisService;
            _searchRequest = hotelbedsRequest;
            _responseMap = responseMapping;
            _mapper = mapper;
        }

        [LogAspect]
        [ValidationAspect(typeof(SearchRequestValidator))]
        public async Task<Result<SearchResponse>> HotelsResponse(SearchRequest request)
        {
            try
            {
                var key = ComputeSHA256.ComputeSha256Hash(JsonSerializer.Serialize(request));
                SearchResponse searchResponse = new();

                if (!_redisService.Any(key))
                {
                    var response = await _searchRequest.SearchInHotelbeds(request);
                    searchResponse.Hotels = GetHotels(response, request);
                    //save as compressed response data
                    _redisService.Add(key, JsonSerializer.Serialize(response));
                }
                else
                {
                    var responseFromCache = _redisService.GetJsonData<AvailabilityRS>(key);
                    searchResponse.Hotels = GetHotels(responseFromCache, request);
                }

                //_publisherService.SendData<SearchResponse>("log", searchResponse);
                return new Result<SearchResponse>(searchResponse, true);
            }
            catch (Exception ex)
            {
                //_publisherService.SendData<string>("log", ex.Message);
                return new Result<SearchResponse>(false,ex.Message);
            }
        }
          
        public List<Hotel> GetHotels(AvailabilityRS response, SearchRequest request)
        {
            var mappedBody = _responseMap.Mapping(response);

            List<Hotel> hotelList = new List<Hotel>();
           
            if(mappedBody.Hotels == null)
            {
                return null;
            }

            foreach (var hotel in mappedBody.Hotels)
            {
                List<RoomGroup> roomGroupList = new List<RoomGroup>();
                List<string> ratekeylist = new();

                foreach (var roomGroup in hotel.roomGroups)
                {
                    List<Policy> policies = new();
                    List<ResponseRoom> roomList = new();

                    foreach (var (item1, index) in roomGroup[0].rate.cancellationPolicies.Select((v, i) => (v, i)))
                    {
                        var policy = roomGroup[0].rate.cancellationPolicies;
                        policies.Add(new Policy
                        {
                            Price = roomGroup.Sum(x => x.rate.cancellationPolicies[index].amount),
                            Currency = hotel.hotelFeatures.currency,
                            Startdate = policy[index].from,
                            Enddate = (policy.Count == 2 && index == 0) ? policy[index + 1].from : request.CheckOut,        
                            PolicyType = (byte)(index + 1)
                        });
                    }
                    
                    foreach (var room in roomGroup)
                    {
                        ratekeylist.Add(room.rate.rateKey);
                        var data = _mapper.Map<ResponseRoom>(room);
                        data.Currency = hotel.hotelFeatures.currency;   
                        roomList.Add(data);
                    }
                    roomGroupList.Add(
                        new RoomGroup
                        {
                            Rooms = roomList,
                            Policies = policies,
                            RateKey = new RateKey { Ratekey = $"{Guid.NewGuid().ToString()}}}+{GenerateKey.CreateKey(ratekeylist, roomGroup.Count)}" }
                        });
                    ratekeylist.Clear();
                }

                var s = hotel.hotelFeatures;
                hotelList.Add(new Hotel
                {
                    Name = (request.Info.HotelName) ? s.name : null,
                    Category = (request.Info.HotelCategory) ? s.categoryName : null,
                    Geolocation = (request.Info.HotelGeoLocation) ? new GeoLocation { Latitude = s.latitude, Longitude = s.longitude } : null,
                    CityName = (request.Info.HotelCityName) ? s.destinationName : null,
                    Code = (request.Info.HotelCode) ? s.code : null,
                    RoomGroups = roomGroupList,
                });
            }
            return hotelList;
        }
    }
}