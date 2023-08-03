using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsHubApp.Business.BusinessModels.HotelbedsModel.messages
{
    public class AbstractGenericRequest
    {
        public string echoToken { get; set; }
        public string language { get; set; }
    }
}
