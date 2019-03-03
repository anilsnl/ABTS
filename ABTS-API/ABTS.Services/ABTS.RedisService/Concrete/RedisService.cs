using System;
using System.Diagnostics.SymbolStore;
using System.Threading.Tasks;
using ABTS.RedisService.Abstract;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace ABTS.RedisService.Concrete
{
    public class RedisService : IRedisService
    {
        private IConfiguration _configuration;
        private readonly IDatabase _redisDb;
        private readonly int expireHour;
        public RedisService(IConfiguration configuration, IRedisConnectionFactory redisConnection)
        {
            _redisDb = redisConnection.GetConnection().GetDatabase();
            this._configuration = configuration;
            this.expireHour = Convert.ToInt32(this._configuration["RedisCache:ExpireHour"]);
        }

        public T Get<T>(string key)
        {
            var redisObject = _redisDb.StringGet(key);
            return redisObject.HasValue ? JsonConvert.DeserializeObject<T>(redisObject) : Activator.CreateInstance<T>();
        }
        public async Task<T> GetAsync<T>(string key)
        {
            var redisObject = await _redisDb.StringGetAsync(key);
            return redisObject.HasValue ? JsonConvert.DeserializeObject<T>(redisObject) : Activator.CreateInstance<T>();
        }
        public async void SetAsync(string key, object value, TimeSpan? expire=null)
        {
            expire = expire ?? TimeSpan.FromHours(this.expireHour);
            await _redisDb.StringSetAsync(key, JsonConvert.SerializeObject(value), expire);
        }
        public void Set(string key, object value, TimeSpan? expire=null)
        {
            expire = expire ?? TimeSpan.FromHours(this.expireHour);
            _redisDb.StringSet(key, JsonConvert.SerializeObject(value), expire);
        }
        public void Delete(string key)
        {
            _redisDb.KeyDelete(key);
        }
        public bool Exists(string key)
        {
            return _redisDb.KeyExists(key);
        }
        public async Task<bool> ExistsAsync(string key)
        {
            return await _redisDb.KeyExistsAsync(key);
        }

        public async Task<T> GetAndSetAsync<T>(string key, Func<Task<T>> getAction,TimeSpan? expire=null)
        {

            if (await _redisDb.KeyExistsAsync(key))
                return await GetAsync<T>(key);
            else
            {
                expire = expire ?? TimeSpan.FromHours(this.expireHour);
                SetAsync(key, await getAction(), expire.Value);
                return await getAction();
            }
        }

    }
}
