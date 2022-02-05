using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Business.BusinessModel.MainModel.model
{
    public class Authentication
    {
        public string Username { get; set; }    
        public string Password { get; set; }
    }
}
