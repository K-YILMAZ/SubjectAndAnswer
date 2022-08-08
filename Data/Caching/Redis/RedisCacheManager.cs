using Data.Redis;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Data.Caching.Redis
{
    public class RedisCacheManager : ICacheManager
    {
        private IDatabase _cache = RedisConnectorHelper.Connection.GetDatabase();
        public void Add(string key, object data, int cacheTime)
        {
            if (data == null) return;
            string jsonData = JsonConvert.SerializeObject(data);

            _cache.StringSet(key, jsonData,TimeSpan.FromMinutes(cacheTime));
        }

        public T Get<T>(string key)
        {
            if (IsAdd(key))
            {
                return JsonConvert.DeserializeObject<T>(_cache.StringGet(key));
            }
            return default;
        }

        public bool IsAdd(string key)
        {
            return _cache.KeyExists(key);
        }

        public void Remove(string key)
        {
           _cache.KeyDelete(key);
        }

        public void RemoveAll()
        {
           RedisConnectorHelper.RemoveAll();
        }
    }
}
