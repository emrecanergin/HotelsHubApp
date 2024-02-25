using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsHubApp.Business.Helper.ResponseMappping.Models
{
    public class MappedBody
    {
        public List<MappedHotel> Hotels { get; set; } = new();
    }
}
