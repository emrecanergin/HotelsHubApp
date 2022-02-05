using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.BusinessModel.MainModel.model
{
    public class Pax
    {
        public int PaxOrder { get; set; }
        public int PaxAge { get; set; }
        public string? PaxName { get; set; }
        public string? PaxSurname { get; set; }
        public string? PaxPrefix { get; set; }
    }
}
