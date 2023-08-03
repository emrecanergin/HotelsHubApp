using HotelsHubApp.Business.Abstract.Hotelbeds.Requests;
using HotelsHubApp.Business.BusinessModels.HotelbedsModel.messages;
using HotelsHubApp.Business.BusinessModels.MainModel.messages;
using HotelsHubApp.Business.Concrete.Hotelbeds.Requests.RequestGenerators;
using HotelsHubApp.Business.HttpClients.HotelbedsClient;
using HotelsHubApp.Core.RabbitMQClient.Abstract;

namespace HotelsHubApp.Business.Concrete.Hotelbeds.Requests
{
    public class HotelbedsSearchRequest : ISearchRequest
    {
        private readonly IHotelApiConsumer _hotelApiConsumer;
        private readonly IPublisherService _publisherService;
        private readonly IAvailabilityRequestBodyGenerator  _availabilityRequestBody;


        public HotelbedsSearchRequest(IHotelApiConsumer hotelApiConsumer,
                                      IPublisherService publisherService,
                                      IAvailabilityRequestBodyGenerator availabilityRequestBody)
        {
            _hotelApiConsumer = hotelApiConsumer;
            _publisherService = publisherService;
            _availabilityRequestBody = availabilityRequestBody;
        }

        public async Task<AvailabilityRS> SearchInHotelbeds(SearchRequest request)
        {
            var requestBody = _availabilityRequestBody.CreateHotelbedsRequestBody(request);
            var response = await _hotelApiConsumer.GetAvailableHotels(requestBody);
            _publisherService.SendData<AvailabilityRS>("responseLog", response);
            return response;
        }
    }
}
