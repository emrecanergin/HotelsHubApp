using HotelsHubApp.Business.BusinessModels.HotelbedsModel.messages;
using HotelsHubApp.Business.BusinessModels.MainModel.messages;
using HotelsHubApp.Business.BusinessModels.MainModel.model;

namespace HotelsHubApp.Business.Concrete.Hotelbeds.Helper.Searching
{
    public interface IGetHotels
    {
        public List<Hotel> Get(AvailabilityRS response, SearchRequest request);
    }
}
