using AutoMapper;
using HotelsHubApp.Business.BusinessModels.HotelbedsModel.messages;
using HotelsHubApp.Business.Helper.ResponseMappping.Models;
using System.Net.Http.Json;

namespace HotelsHubApp.Business.Helper.ResponseMappping
{
    public class ResponseMap : IResponseMap
    {
        public MappedBody MappedBody { get; set; } = new();
        private readonly IMapper _mapper;
        public ResponseMap(IMapper mapper)
        {
            _mapper = mapper;
        }
        public MappedBody Mapping(AvailabilityRS body)
        {
            if(body.hotels.hotels == null)
            {
                var res = new MappedBody { Hotels = null };
                return res;
            }
            foreach (var hotel in body.hotels.hotels)
            {
                SingleHotel singleHotel = new();
                List<Room> roomList = new List<Room>();
                MappedHotel mappedHotel = new();

                foreach (var room in hotel.rooms)
                {
                    foreach (var rate in room.rates)
                    {
                        var newRoom = new Room
                        {
                            roomname = room.name.ToString(),
                            rate = rate
                        };
                        roomList.Add(newRoom);
                    }
                }

                HotelFeatures hotelFeatures = _mapper.Map<HotelFeatures>(hotel);

                singleHotel.rooms = roomList;
                singleHotel.hotelFeatures = hotelFeatures;

                var groupedList = singleHotel.rooms.GroupBy(x => (x.rate.rooms, x.rate.adults, x.rate.children, x.rate.childrenAges)).ToList();

                switch (groupedList.Count)
                {
                    case 1:
                        {
                            mappedHotel.hotelFeatures = hotelFeatures;
                            singleHotel.rooms.ForEach(x => mappedHotel.roomGroups.Add(new List<Room> { x }));
                            MappedBody.Hotels.Add(mappedHotel);
                            break;
                        }
                    case 2:
                        {
                            var result1 = Query.JoinTwoList(groupedList[0], groupedList[1]);
                            result1.ToList().ForEach(x => mappedHotel.roomGroups.Add(new List<Room> { x.a, x.b }));
                            mappedHotel.hotelFeatures = hotelFeatures;
                            MappedBody.Hotels.Add(mappedHotel);
                            break;
                        }
                    case 3:
                        {
                            var result1 = Query.JoinThreeList(groupedList[0], groupedList[2], groupedList[2]);
                            result1.ToList().ForEach(x => mappedHotel.roomGroups.Add(new List<Room> { x.a, x.b, x.c }));
                            mappedHotel.hotelFeatures = hotelFeatures;
                            MappedBody.Hotels.Add(mappedHotel);
                            break;
                        }
                    case 4:
                        {
                            var result1 = Query.JoinFourList(groupedList[0], groupedList[2], groupedList[2], groupedList[3]);
                            result1.ToList().ForEach(x => mappedHotel.roomGroups.Add(new List<Room> { x.a, x.b, x.c, x.d }));
                            mappedHotel.hotelFeatures = hotelFeatures;
                            MappedBody.Hotels.Add(mappedHotel);
                            break;
                        }
                }
            }
            return MappedBody;
        }
    }
}
