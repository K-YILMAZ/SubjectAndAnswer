using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Caching.Redis
{
    public class RedisConnectorHelper
    {
        static RedisConnectorHelper()
        {
            _connectionMultiplexer = ConnectionMultiplexer.Connect("localhost");
            _database = _connectionMultiplexer.GetDatabase(0);
            _lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return _connectionMultiplexer;
            });
        }

        private static Lazy<ConnectionMultiplexer> _lazyConnection;
        private static ConnectionMultiplexer _connectionMultiplexer;

        private static IDatabase _database;

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return _lazyConnection.Value;
            }
        }
        public static void RemoveAll()
        {
            _connectionMultiplexer.GetServer("localhost").FlushDatabase(0);
        }
    }

}
