using Business.BusinessModel.HotelbedsModel.util;
using HotelsHubApp.Business.BusinessModels.HotelbedsModel.common;
using Newtonsoft.Json;


namespace HotelsHubApp.Business.BusinessModels.HotelbedsModel.model
{
    public class Pax
    {
        public int? roomId { get; set; }
        [JsonProperty("type", Required = Required.Always)]
        [JsonConverter(typeof(JSonConverters.HotelbedsCustomerTypeConverter))]
        public SimpleTypes.HotelbedsCustomerType? type { get; set; }
        public int? age { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
    }
}
