using HotelsHubApp.Core.RedisClient.Options;
using Microsoft.Extensions.Options;
using StackExchange.Redis;


namespace HotelsHubApp.Core.RedisClient.Concrete
{
    public class RedisServer
    {
        private readonly ConnectionMultiplexer _connectionMultiplexer;     
        private readonly IOptions<RedisOptions> _redisOptions;
       
        public RedisServer(IOptions<RedisOptions> redisOptions)
        {
            _redisOptions = redisOptions;          
            _connectionMultiplexer = ConnectionMultiplexer.Connect("localhost:1923");
        }

        public IDatabase Database(int databaseId) 
        {
            return _connectionMultiplexer.GetDatabase(databaseId);
        
        }
        public void FlushDatabase(int databaseId)
        {
            _connectionMultiplexer.GetServer(_redisOptions.Value.Configuration).FlushDatabase(databaseId);
        }

        public ConfigurationOptions CreateRedisConfigurationOptions()
        {
            var config = _redisOptions.Value.ConfigurationOptions;
            return config;
        }
    }
}
