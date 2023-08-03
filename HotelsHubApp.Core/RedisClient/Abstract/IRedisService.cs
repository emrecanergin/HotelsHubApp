﻿namespace HotelsHubApp.Core.RedisClient.Abstract
{
    public interface IRedisService
    {
        T GetJsonData<T>(string key);
        string GetValue(string key);
        void Add(string key, string value);
        void Remove(string key);
        void Clear();
        bool Any(string key);
    }
}
