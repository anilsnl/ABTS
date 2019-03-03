using System;
using ABTS.RedisService.Abstract;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace ABTS.RedisService.Concrete
{
    public class RedisConnectionFactory:IRedisConnectionFactory
    {
       
        public RedisConnectionFactory(IConfiguration configuration)
        {
            lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect(configuration.GetConnectionString("RedisCache"));//redis server conn string bilgisi, web config'den almak daha doğru ancak şimdilik buraya yazdık
            });
        }

        private  Lazy<ConnectionMultiplexer> lazyConnection;

        public  ConnectionMultiplexer Connection => lazyConnection.Value;

        

        public ConnectionMultiplexer GetConnection()
        {
            return this.Connection;
        }     

        public void DisposeConnection()
        {
            if (lazyConnection.Value.IsConnected)
                lazyConnection.Value.Dispose();
        }
    }
}