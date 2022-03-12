using HotelsHubApp.Business.BusinessModels.HotelbedsModel.messages;
using HotelsHubApp.Business.BusinessModels.MainModel.messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsHubApp.Business.Abstract.Hotelbeds.Requests
{
    public interface ICheckRateRequest
    {
        public Task<CheckRateRS> CheckRate(CheckRequest checkRequest);
    }
}
