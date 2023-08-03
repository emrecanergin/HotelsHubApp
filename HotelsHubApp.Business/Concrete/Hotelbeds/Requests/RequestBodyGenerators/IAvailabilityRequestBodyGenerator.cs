using HotelsHubApp.Business.BusinessModels.HotelbedsModel.messages;
using HotelsHubApp.Business.BusinessModels.MainModel.messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsHubApp.Business.Concrete.Hotelbeds.Requests.RequestGenerators
{
    public interface IAvailabilityRequestBodyGenerator
    {
        public AvailabilityRQ CreateHotelbedsRequestBody(SearchRequest request);
    }
}
