using HotelsHubApp.Business.BusinessModels.HotelbedsModel.model;
using HotelsHubApp.Business.BusinessModels.MainModel.messages;

namespace HotelsHubApp.Business.BusinessModels.HotelbedsModel.messages
{
    public class CheckRateRQ : AbstractGenericRequest
    {
        public bool upselling { get; set; }
        public IList<CheckRateRoom> rooms { get; set; }
    }
}
