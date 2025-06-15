using Newtonsoft.Json;
using System.Net;

namespace HotelsHubApp.WebAPI
{
    public class PaginationInfo
    {
        [JsonProperty(Order = 1)]
        public int CurrentPage { get; set; }
        
        [JsonProperty(Order = 2)]
        public int PageSize { get; set; }
        
        [JsonProperty(Order = 3)]
        public int TotalItems { get; set; }
        
        [JsonProperty(Order = 4)]
        public int TotalPages { get; set; }
        
        [JsonProperty(Order = 5)]
        public bool HasNextPage { get; set; }
        
        [JsonProperty(Order = 6)]
        public bool HasPreviousPage { get; set; }
    }

    public class ApiResponse<T> where T : class
    {
        //FOR XML RESPONSE
        public ApiResponse()
        {

        }
        public ApiResponse(T extra)
        {
            Success = true;
            Data = extra;
            TimeStamps = DateTime.UtcNow;
        }

        public ApiResponse(string errorMessage)
        {
            Success = false;
            ErrorMessage = errorMessage;
            TimeStamps = DateTime.UtcNow;  
        }

        public int StatusCode { get; set; }
        
        public T Data { get; set; }

        [JsonProperty(Order = -2)]
        public bool Success { get; set; }
       
        [JsonProperty(Order = -4)]
        public DateTime TimeStamps { get; set; }
        
        [JsonProperty(Order = -3)]
        public string TotalProcessTime { get; set; }
        
        public string ErrorMessage { get; set; }

        public PaginationInfo? Pagination { get; set; }

    }
}
