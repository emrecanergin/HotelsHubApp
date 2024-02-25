using AutoMapper;
using HotelsHubApp.Business.BusinessModels.HotelbedsModel.messages;
using HotelsHubApp.Business.BusinessModels.MainModel.messages;
using HotelsHubApp.Business.BusinessModels.MainModel.model;
using HotelsHubApp.Business.Helper;
using HotelsHubApp.Business.Helper.ResponseMappping;


namespace HotelsHubApp.Business.Concrete.Hotelbeds.Helper.Searching
{
    public class GetHotels : IGetHotels
    {
        private readonly IResponseMap _responseMap;
        private readonly IMapper _mapper;

        public GetHotels(IResponseMap responseMapping,
                         IMapper mapper)
        {         
            _responseMap = responseMapping;
            _mapper = mapper;
        }    

        public List<Hotel> Get(AvailabilityRS response, SearchRequest request)
        {
            var mappedBody = _responseMap.Mapping(response);

            List<Hotel> hotelList = new List<Hotel>();

            if (mappedBody.Hotels == null)
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