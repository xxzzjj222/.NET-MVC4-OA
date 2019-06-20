using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;
using System.Configuration;

namespace RedisDemo
{
    public class RedisManager
    {
        private static string RedisPath = System.Configuration.ConfigurationManager.AppSettings["RedisPath"];
        private static PooledRedisClientManager _prcm;

        static RedisManager()
        {
            CreateManager();
        }

        public static IRedisClient GetClient()
        {
            if (_prcm == null)
            {
                CreateManager(new string[] { RedisPath }, new string[] { RedisPath });
            }
            return _prcm.GetClient();
        }
        public static void CreateManager()
        {
            _prcm=CreateManager(new string[] { RedisPath }, new string[] { RedisPath });
        }
        public static PooledRedisClientManager CreateManager(string[] readWriteHost,string[] readOnlyHost)
        {
            return new PooledRedisClientManager(readWriteHost, readOnlyHost,new RedisClientManagerConfig{
                MaxWritePoolSize=5,
                MaxReadPoolSize=5,
                AutoStart=true
            });
        }
    }
}
