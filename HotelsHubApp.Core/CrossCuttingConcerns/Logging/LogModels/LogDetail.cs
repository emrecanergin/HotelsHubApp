using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsHubApp.Core.CrossCuttingConcerns.Logging.LogModels
{
    public class LogDetail
    {
        public LogDetail()
        {
            TimeStamp = DateTime.Now;
        }
        public DateTime TimeStamp { get; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string MethodName { get; set; }
        public List<LogParameter> Parameters { get; set; }
        public string Exception { get; set; }
    }
}
