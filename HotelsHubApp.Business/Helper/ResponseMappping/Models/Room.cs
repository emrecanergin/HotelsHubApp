using HotelsHubApp.Business.BusinessModels.HotelbedsModel.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsHubApp.Business.Helper.ResponseMappping.Models
{
    public class Room
    {
        public string roomname { get; set; }
        public Rate rate { get; set; }
    }
}
