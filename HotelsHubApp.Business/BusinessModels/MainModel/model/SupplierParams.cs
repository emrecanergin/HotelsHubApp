using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsHubApp.Business.BusinessModels.MainModel.bookingModel
{
    public class SupplierParams
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string SearchUrl { get; set; }
        public string ValuationUrl { get; set; }
        public string ConfirmationUrl { get; set; }
        public string CommonUrl { get; set; }
        public object AdditionalParameters { get; set; }
    }
}
