using Business.BusinessModel.HotelbedsModel.util;
using HotelsHubApp.Business.BusinessModels.HotelbedsModel.common;
using HotelsHubApp.Business.BusinessModels.HotelbedsModel.model;
using Newtonsoft.Json;

namespace HotelsHubApp.Business.BusinessModels.HotelbedsModel.messages
{
    public class AvailabilityRQ : AbstractGenericRequest
    {
        public Stay stay { get; set; }
        public List<Occupancy> occupancies { get; set; }
        public GeoLocation geolocation { get; set; }
        public Destination destination { get; set; }
        public HotelsFilter hotels { get; set; }

        //public List<ReviewFilter> reviews { get; set; }
        public Filter filter { get; set; }
        public Boards boards { get; set; }
        public Rooms rooms { get; set; }
        public bool dailyRate { get; set; }
        //public Source source { get; set; }
        public string sourceMarket { get; set; }
        [JsonProperty("accommodations" /*Required = Required.Always*/)]
        [JsonConverter(typeof(JSonConverters.AccommodationTypeConverter))]
        public List<SimpleTypes.AccommodationType> accommodations { get; set; }
    }
}
