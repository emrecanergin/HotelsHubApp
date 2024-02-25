using HotelsHubApp.Business.BusinessModels.HotelbedsModel.messages;
using HotelsHubApp.Business.BusinessModels.MainModel.messages;

namespace HotelsHubApp.Business.Abstract.Hotelbeds.Requests
{
    public interface ICheckRateRequest
    {
        public Task<CheckRateRS> CheckRate(CheckRequest checkRequest);
    }
}
