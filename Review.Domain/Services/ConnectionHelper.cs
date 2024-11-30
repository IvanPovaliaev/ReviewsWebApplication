using StackExchange.Redis;

namespace Review.Domain.Services
{
    public class ConnectionHelper
    {
        private static readonly Lazy<ConnectionMultiplexer> lazyConnection;
        public static ConnectionMultiplexer Connection
        {
            get => lazyConnection.Value;
        }

        static ConnectionHelper()
        {
            lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect(ConfigurationManager.AppSetting["RedisURL"]);
            });
        }


    }
}
