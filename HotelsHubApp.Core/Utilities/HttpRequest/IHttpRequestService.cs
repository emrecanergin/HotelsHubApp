using System.Threading.Tasks;

namespace HotelsHubApp.Core.Utilities.HttpRequest
{
    public interface IHttpRequestService<T> where T : class
    {
        public T deserializedClass { get; set; }
        Task<T> PostRequestAsync(object requestBody, string clientname, string target);
        Task<T> GetRequestAsync(string clientname, string target);

    }
}
