using System.Threading.Tasks;

namespace HotelsHubApp.Core.Utilities.HttpRequest.HotelbedsAPI
{
    public interface IHttpRequestService<T> where T : class
    {
        public T deserializedClass { get; set; }
        Task<T> PostRequestAsync(object requestBody, string target);
        Task<T> GetRequestAsync(string target);

    }
}
