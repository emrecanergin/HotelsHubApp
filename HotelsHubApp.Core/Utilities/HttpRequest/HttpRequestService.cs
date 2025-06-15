using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using HotelsHubApp.Business.HttpRequests.Helper;

namespace HotelsHubApp.Core.Utilities.HttpRequest
{

    public class HttpRequestService<T> : IHttpRequestService<T> where T : class
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public T deserializedClass { get; set; }
        
        public HttpRequestService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<T> PostRequestAsync(object requestBody, string clientname, string target)
        {
            var client = _httpClientFactory.CreateClient(clientname);
            
            // Hotelbeds request için dinamik X-Signature hesaplama
            if (clientname == "HotelbedsRequest")
            {
                var apiKey = _configuration["Hotelbeds:ApiKey"] ?? "apikey";
                var secretKey = _configuration["Hotelbeds:SecretKey"] ?? "sharedsecret";
                var signature = Signature.CreateSignature(apiKey, secretKey);
                
                // Mevcut X-Signature header'ını kaldır ve yenisini ekle
                client.DefaultRequestHeaders.Remove("X-Signature");
                client.DefaultRequestHeaders.Add("X-Signature", signature);
            }
            
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
