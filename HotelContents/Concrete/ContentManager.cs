using HotelContents.Abstract;
using HotelContents.Models;
using HotelsHubApp.Business.HttpRequests.Helper;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HotelContents.Concrete
{
    public class ContentManager : IContentService
    {
        private readonly IHttpClientFactory _clientFactory;
        public ContentManager(IHttpClientFactory httpClientFactory)
        {
            _clientFactory = httpClientFactory;
        }

        public async Task<ContentRS> GetContent(int from,int to,string destinationCode,string countryCode)
        {
            var client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri("https://api.test.hotelbeds.com/hotel-content-api/1.0/hotels");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Accept-Encoding", "*");
            client.DefaultRequestHeaders.Add("Api-key", "");
            client.DefaultRequestHeaders.Add("X-Signature", Signature.CreateSignature());
            
            HttpResponseMessage data = await client.GetAsync($"?from={from}&to={to}&destinationCode={destinationCode}");
            
            data.EnsureSuccessStatusCode(); 
            
            var json = await data.Content.ReadAsStringAsync();

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
            };
            var deserialized = JsonSerializer.Deserialize<ContentRS>(json);
            return deserialized;


        }
    }
}
