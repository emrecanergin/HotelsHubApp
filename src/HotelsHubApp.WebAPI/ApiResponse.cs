using Newtonsoft.Json;
using System.Net;

namespace HotelsHubApp.WebAPI
{ 
    public class ApiResponse<T> where T : class
    {
        //FOR XML RESPONSE
        public ApiResponse()
        {

        }
        public ApiResponse(T extra)
        {
            this.Success = true;
            this.Data = extra;
            this.TimeStamps = DateTime.UtcNow;
        }

        public ApiResponse(string errorMessage)
        {
            this.Success = false;
            this.ErrorMessage = errorMessage;
            this.TimeStamps = DateTime.UtcNow;  
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

    }
}
