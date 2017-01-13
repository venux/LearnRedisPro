using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace RedisDemo
{
    internal class RedisHelper
    {
        public RedisHelper()
        {

        }

        /// <summary>
        /// Redis链接
        /// </summary>
        public static ConnectionMultiplexer Connection
        {
            get
            {
                try
                {
                    return lazyConnection.Value;
                }
                catch
                {
                    return null;
                }
            }
        }

        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            ConfigurationOptions options = new ConfigurationOptions();
            options.ClientName = "Client1";
            options.ServiceName = "localhost";
            //options.Password = System.Configuration.ConfigurationManager.AppSettings["RedisPassword"];
            options.AbortOnConnectFail = false;
            options.SyncTimeout = 5000;
            options.EndPoints.Add("myreids");

            return ConnectionMultiplexer.Connect(options);
        });
    }
}
