
using StackExchange.Redis;

namespace MultiShopMicroservices.Basket.Settings
{
    public class RedisService
    {
        private readonly Lazy<ConnectionMultiplexer> _connectionMultiplexer;

        public RedisService(string host, int port)
        {
            var options = new ConfigurationOptions
            {
                EndPoints = { $"{host}:{port}" },
                AbortOnConnectFail = false // 🔥 EN KRİTİK NOKTA
            };

            _connectionMultiplexer = new Lazy<ConnectionMultiplexer>(
                () => ConnectionMultiplexer.Connect(options)
            );
        }

        public IDatabase GetDb(int db = 0)
        {
            return _connectionMultiplexer.Value.GetDatabase(db);
        }
    }
}
