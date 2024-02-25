using HotelsHubApp.Business.BusinessModels.MainModel.messages;
using HotelsHubApp.Core.Utilities.Results;

namespace HotelsHubApp.Business.Abstract.Hotelbeds.Services
{
    public  interface ICheckRateService
    {
        public Task<Result<CheckResponse>> CheckRateResponse(CheckRequest request);
    }
}
