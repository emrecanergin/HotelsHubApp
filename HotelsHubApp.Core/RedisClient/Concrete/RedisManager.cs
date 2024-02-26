using HotelsHubApp.Core.RedisClient.Abstract;
using System.Text.Json;

namespace HotelsHubApp.Core.RedisClient.Concrete
{
    public class RedisManager : IRedisService
    {
        RedisServer _redisServer;
        public RedisManager(RedisServer redisServer)
        {
            _redisServer = redisServer;
        }
        public void Add(string key, string value)
        {
            _redisServer.Database(0).StringSet(key, value);
        }
        public void Add(string key, string value,TimeSpan expireTime)
        {
            _redisServer.Database(0).StringSet(key, value, expireTime);
        }
        public bool Any(string key)
        {
            return _redisServer.Database(0).KeyExists(key);
        }

        public void Clear()
        {
            _redisServer.FlushDatabase(0);
        }

        public T GetJsonData<T>(string key)
        {
            if (Any(key))
            {
                var jsonData = _redisServer.Database(0).StringGet(key);
                return JsonSerializer.Deserialize<T>(jsonData);
            }
            return default;
        }

        public string GetValue(string key)
        {
            return _redisServer.Database(0).StringGet(key);
        } 

        public void Remove(string key)
        {
            _redisServer.Database(0).KeyDelete(key);
        }
    }
}
