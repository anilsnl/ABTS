using StackExchange.Redis;

namespace ABTS.RedisService.Abstract
{
    public interface IRedisConnectionFactory
    {      
        ConnectionMultiplexer GetConnection();

        void DisposeConnection();
    }
}