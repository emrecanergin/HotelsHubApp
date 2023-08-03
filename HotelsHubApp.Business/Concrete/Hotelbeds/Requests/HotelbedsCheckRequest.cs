using HotelsHubApp.Business.Abstract.Hotelbeds.Requests;
using HotelsHubApp.Business.BusinessModels.HotelbedsModel.messages;
using HotelsHubApp.Business.BusinessModels.HotelbedsModel.model;
using HotelsHubApp.Business.BusinessModels.MainModel.messages;
using HotelsHubApp.Business.HttpClients.HotelbedsClient;
using HotelsHubApp.Business.HttpRequests.Hotelbeds;

namespace HotelsHubApp.Business.Concrete.Hotelbeds.Requests
{
    public class HotelbedsCheckRequest : ICheckRateRequest
    {
        private readonly IHotelApiConsumer _hotelApiConsumer;

        public HotelbedsCheckRequest(IHotelApiConsumer hotelApiConsumer)
        {
            hotelApiConsumer = _hotelApiConsumer;
        }
        public async Task<CheckRateRS> CheckRate(CheckRequest checkRequest)
        {
            string[] result = checkRequest.rooms.rateKey.Split(new[] { "½", "&", "$" }, StringSplitOptions.None);
            var list = result.ToList();
            list.RemoveAt(list.Count - 1);
            list.RemoveAt(0);
            
            var roomList = new List<CheckRateRoom>();
            for (int i = 0; i < list.Count; i++)
            {
                roomList.Add(new CheckRateRoom { rateKey = list[i] });
            }


            var request = new CheckRateRQ { rooms = roomList };

            var response = await _hotelApiConsumer.CheckRate(request);
            return response;
        }
    }
}
