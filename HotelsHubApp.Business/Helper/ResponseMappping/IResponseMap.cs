using HotelsHubApp.Business.BusinessModels.HotelbedsModel.messages;
using HotelsHubApp.Business.Helper.ResponseMappping.Models;

namespace HotelsHubApp.Business.Helper.ResponseMappping
{
    public interface IResponseMap
    {
        public MappedBody Mapping(AvailabilityRS body);
    }
}
