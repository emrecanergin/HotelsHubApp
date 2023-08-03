using StackExchange.Redis;

namespace HotelsHubApp.Core.RedisClient.Options
{
    public class RedisOptions
    {
        public string Configuration { get; set; }
        public ConfigurationOptions ConfigurationOptions { get; set; }
        public object InstanceName { get; set; }
    }
}
