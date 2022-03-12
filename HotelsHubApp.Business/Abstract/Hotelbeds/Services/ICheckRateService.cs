using HotelsHubApp.Business.BusinessModels.HotelbedsModel.messages;
using HotelsHubApp.Business.BusinessModels.MainModel.messages;
using HotelsHubApp.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsHubApp.Business.Abstract.Hotelbeds.Services
{
    public  interface ICheckRateService
    {
        public Task<Result<CheckResponse>> CheckRateResponse(CheckRequest request);
    }
}
