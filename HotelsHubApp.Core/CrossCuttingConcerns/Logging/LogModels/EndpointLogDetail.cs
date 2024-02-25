using System;

namespace HotelsHubApp.Core.CrossCuttingConcerns.Logging.LogModels
{
    public class EndpointLogDetail
    {
        public string RequestMethod { get; set; }
        public string RequestContent { get; set; }
        public DateTime RequestTimestamp { get; set; }
        public Uri RequestUri { get; set; }
        public string RequestPath { get; set; }
        public long ResponseTime { get; set; }
        public string ResponseContentType { get; set; }
        public string ResponseStatusCode { get; set; }
        public string Exception { get; set; }
    }
}
