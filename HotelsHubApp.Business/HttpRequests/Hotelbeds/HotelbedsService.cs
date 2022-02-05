using HotelsHubApp.Business.BusinessModels.HotelbedsModel.messages;
using HotelsHubApp.Business.HttpRequests.Helper;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HotelsHubApp.Business.HttpRequests.Hotelbeds
{
    public class HotelbedsService
    {
        private readonly HttpClient _httpClient;
        const string hotel = "hotel-api/1.0/";
        const string content = "hotel-content-api/1.0/";
        public HotelbedsService(HttpClient httpClient)
        {
            _httpClient = httpClient;   
            _httpClient.BaseAddress = new Uri("https://api.test.hotelbeds.com/");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "*");
            _httpClient.DefaultRequestHeaders.Add("Api-key", "api-key");
            _httpClient.DefaultRequestHeaders.Add("X-Signature", Signature.CreateSignature());
        }
        
        public async Task<AvailabilityRS> GetAvailableHotels(AvailabilityRQ searchRequestBody)
        {
            HttpContent requestJson = new StringContent(JsonSerializer.Serialize(searchRequestBody),
                                                        Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = await _httpClient.PostAsync($"{hotel}hotels", requestJson);
       
            httpResponse.EnsureSuccessStatusCode();

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                NumberHandling = JsonNumberHandling.WriteAsString | 
                                 JsonNumberHandling.AllowReadingFromString
            };
            var data = await httpResponse.Content.ReadAsStringAsync();
            AvailabilityRS response = JsonSerializer.Deserialize<AvailabilityRS>(data,options);

            return response;
        }
    }
}
