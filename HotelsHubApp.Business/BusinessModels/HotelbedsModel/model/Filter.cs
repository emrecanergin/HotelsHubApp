using Business.BusinessModel.HotelbedsModel.util;
using HotelsHubApp.Business.BusinessModels.HotelbedsModel.common;
using Newtonsoft.Json;

namespace HotelsHubApp.Business.BusinessModels.HotelbedsModel.model
{
    public class Filter
    {
        public int maxHotels { get; set; }
        public int maxRooms { get; set; }
        public int minRate { get; set; }
        public int maxRate { get; set; }
        public int maxRatesPerRoom { get; set; }
        public bool packaging { get; set; }
        [JsonProperty("paymentType", Required = Required.Always)]
        [JsonConverter(typeof(JSonConverters.ShowDirectPaymentTypeConverter))]
        public SimpleTypes.ShowDirectPaymentType? paymentType { get; set; }
        [JsonProperty("hotelPackage" , Required = Required.Always)]
        [JsonConverter(typeof(JSonConverters.HotelPackageConverter))]
        public SimpleTypes.HotelPackage? hotelPackage { get; set; }
        public int minCategory { get; set; }
        public int maxCategory { get; set; }
    }
}
