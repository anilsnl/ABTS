using System;
using System.Threading.Tasks;

namespace ABTS.RedisService.Abstract
{
    public interface IRedisService
    {
        T Get<T>(string key);
        Task<T> GetAsync<T>(string key);
        Task SetAsync(string key, object value, TimeSpan? expire=null);
        void Set(string key, object value, TimeSpan? expire=null);
        Task<T> GetAndSetAsync<T>(string key, Func<Task<T>> getAction,TimeSpan? expire=null);
    }
}