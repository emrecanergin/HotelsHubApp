using HotelsHubApp.Business.BusinessModels.HotelbedsModel.messages;
using HotelsHubApp.Business.HttpRequests.Helper;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HotelsHubApp.Business.HttpRequests.Hotelbeds
{
    public class HotelApiConsumer
    {
        private readonly HttpClient _httpClient;
        const string checkrates = "hotel-api/1.0/checkrates";
        const string hotels = "hotel-api/1.0/hotels";
        const string bookings = "hotel-api/1.0/bookings";

        public HotelApiConsumer(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.test.hotelbeds.com/");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "*");
            _httpClient.DefaultRequestHeaders.Add("Api-key", "*");
            _httpClient.DefaultRequestHeaders.Add("X-Signature", Signature.CreateSignature());
        }

        public async Task<AvailabilityRS> GetAvailableHotels(AvailabilityRQ searchRequestBody)
        {
            HttpContent requestJson = new StringContent(JsonSerializer.Serialize(searchRequestBody),
                                                        Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = await _httpClient.PostAsync(hotels, requestJson);

            httpResponse.EnsureSuccessStatusCode();

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                NumberHandling = JsonNumberHandling.WriteAsString |
                                 JsonNumberHandling.AllowReadingFromString
            };
            var data = await httpResponse.Content.ReadAsStringAsync();
            AvailabilityRS response = JsonSerializer.Deserialize<AvailabilityRS>(data, options);

            return response;
        }

        public async Task<CheckRateRS> CheckRate(CheckRateRQ checkRateRequestBody)
        {
            HttpContent requestJson = new StringContent(JsonSerializer.Serialize(checkRateRequestBody),
                                                       Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = await _httpClient.PostAsync(checkrates, requestJson);

            httpResponse.EnsureSuccessStatusCode();

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                NumberHandling = JsonNumberHandling.WriteAsString |
                                 JsonNumberHandling.AllowReadingFromString
            };
            var data = await httpResponse.Content.ReadAsStringAsync();
            CheckRateRS response = JsonSerializer.Deserialize<CheckRateRS>(data, options);

            return response;
        }

        public async Task<BookingRS> Book(BookingRQ bookingRequestBody)
        {
            HttpContent requestJson = new StringContent(JsonSerializer.Serialize(bookingRequestBody),
                                                      Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = await _httpClient.PostAsync(bookings, requestJson);

            httpResponse.EnsureSuccessStatusCode();

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                NumberHandling = JsonNumberHandling.WriteAsString |
                                 JsonNumberHandling.AllowReadingFromString
            };
            var data = await httpResponse.Content.ReadAsStringAsync();
            BookingRS response = JsonSerializer.Deserialize<BookingRS>(data, options);

            return response;
        }
    }
}
