using HotelsHubApp.Core.RedisClient.Options;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System.Linq;


namespace HotelsHubApp.Core.RedisClient.Concrete
{
    public class RedisServer
    {
        private readonly ConnectionMultiplexer _connectionMultiplexer;     
        private readonly IOptions<RedisOptions> _redisOptions;
       
        public RedisServer(IOptions<RedisOptions> redisOptions)
        {
            _redisOptions = redisOptions;
            var connectionString = _redisOptions.Value.Configuration ?? "redis:6379";
            _connectionMultiplexer = ConnectionMultiplexer.Connect(connectionString);
        }

        public IDatabase Database(int databaseId) 
        {
            ConfigurationOptions configurationOptions = new ConfigurationOptions();
            
            return _connectionMultiplexer.GetDatabase(databaseId);
        
        }
        public void FlushDatabase(int databaseId)
        {
            var endpoint = _connectionMultiplexer.GetEndPoints().FirstOrDefault();
            if (endpoint != null)
            {
                _connectionMultiplexer.GetServer(endpoint).FlushDatabase(databaseId);
            }
        }

        public ConfigurationOptions CreateRedisConfigurationOptions()
        {
            var config = new ConfigurationOptions();
            config.EndPoints.Add(_redisOptions.Value.Configuration ?? "redis:6379");
            return config;
        }
    }
}
