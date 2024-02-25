using System.Collections.Generic;

namespace HotelsHubApp.Business.BusinessModels.HotelbedsModel.model
{
    public class BookingRoom
    {
        public string rateKey { get; set; }
        public List<Pax> paxes;
    }
}
