using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Commom.Cache
{
    public class CacheHelper
    {
        private static ICacheWriter CacheWriter { get; set; }
        static CacheHelper()
        {
            IApplicationContext ctx = ContextRegistry.GetContext();
            //ctx.GetObject("CacheHelper");

            CacheWriter = ctx.GetObject("CacheWriter") as ICacheWriter;
        }
        public static void AddCache(string key,object value,DateTime expTime)
        {
            CacheWriter.AddCache(key, value, expTime);
        }
        public static void AddCache(string key, object value)
        {
            CacheWriter.AddCache(key, value);
        }
        public static object GetCache(string key)
        {
            return CacheWriter.GetCache(key);
        }
        public static void SetCache(string key,object value,DateTime expTime)
        {
            CacheWriter.SetCache(key, value, expTime);
        }
        public static void SetCache(string key, object value)
        {
            CacheWriter.SetCache(key, value);
        }
    }
}
