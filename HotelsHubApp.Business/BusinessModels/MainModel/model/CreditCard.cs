using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessModel.MainModel.model
{
    public class CreditCard
    {
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public string CardHolder { get; set; }
        public string ExpireMonth { get; set; }
        public string ExpireYear { get; set; }
        public string Cvv { get; set; }
    }
}
