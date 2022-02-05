using Business.BusinessModel.HotelbedsModel.util;
using HotelsHubApp.Business.BusinessModels.HotelbedsModel.common;
using Newtonsoft.Json;


namespace HotelsHubApp.Business.BusinessModels.HotelbedsModel.model
{
    public class Source
    {
        [JsonProperty("channel", Required = Required.Always)]
        [JsonConverter(typeof(JSonConverters.ChannelTypeConverter))]
        public SimpleTypes.ChannelType? channel { get; set; }
        [JsonProperty("device", Required = Required.Always)]
        [JsonConverter(typeof(JSonConverters.DeviceTypeConverter))]
        public SimpleTypes.DeviceType? device { get; set; }
        public String deviceInfo { get; set; }
    }
}
