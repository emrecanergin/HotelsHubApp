using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HotelsHubApp.Core.Utilities.HttpRequest
{

    public class HttpRequestService<T> : IHttpRequestService<T> where T : class
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public T deserializedClass { get; set; }
        public HttpRequestService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> PostRequestAsync(object requestBody, string clientname, string target)
        {
            var client = _httpClientFactory.CreateClient(clientname);
            //client.Timeout = TimeSpan.FromMilliseconds(5);
            HttpContent resJson = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = await client.PostAsync($"{target}", resJson);

            //returns httpResponseMessage
            httpResponse.EnsureSuccessStatusCode();

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                NumberHandling = JsonNumberHandling.AllowReadingFromString |
                JsonNumberHandling.WriteAsString,
            };

            var data = await httpResponse.Content.ReadAsStringAsync();
            deserializedClass = JsonSerializer.Deserialize<T>(data, options);

            return deserializedClass;
        }

        public async Task<T> GetRequestAsync(string clientname, string target)
        {
            var client = _httpClientFactory.CreateClient("HotelbedsRequest");
            HttpResponseMessage httpResponse = await client.GetAsync($"{target}");

            //returns httpResponseMessage
            httpResponse.EnsureSuccessStatusCode();

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                NumberHandling = JsonNumberHandling.AllowReadingFromString |
                JsonNumberHandling.WriteAsString,
            };

            var data = await httpResponse.Content.ReadAsStringAsync();
            deserializedClass = JsonSerializer.Deserialize<T>(data, options);

            return deserializedClass;
        }
    }
}
