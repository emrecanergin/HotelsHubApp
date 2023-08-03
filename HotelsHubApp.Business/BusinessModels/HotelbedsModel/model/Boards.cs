using Business.BusinessModel.HotelbedsModel.util;
using Newtonsoft.Json;

namespace HotelsHubApp.Business.BusinessModels.HotelbedsModel.model
{
    public class Boards
    {
        public List<String> board { get; set; }
        [JsonProperty("included", Required = Required.Always)]
        [JsonConverter(typeof(JSonConverters.BooleanConverter))]
        public bool? included { get; set; }
    }
}
