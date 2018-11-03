using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cache
{
    public class RedisCacheWriter : ICache
    {
        private IRedisClient redisClient = new RedisClient("127.0.0.1", 6379, null);//redis服务IP和端口


        public void AddCache(string key, object value)
        {
            redisClient.Add(key, value);
        }

        public void AddCache(string key, object value, DateTime expiredTime)
        {
            redisClient.Add(key, value, expiredTime);
        }

        public object GetCache(string key)
        {
            return redisClient.Get<object>(key);
        }

        public T GetCache<T>(string key)
        {
            return (T)redisClient.Get<object>(key);
        }

        public void SetCache(string key, object value)
        {
            redisClient.Set(key, value);
        }

        public void SetCache(string key, object value, DateTime expiredTime)
        {
            redisClient.Set(key, value, expiredTime);
        }
        public Int64 Increment(string key, uint amount)
        {
            return redisClient.Increment(key, amount);
        }
    }
}
