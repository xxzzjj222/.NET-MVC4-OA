using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace OA.Commom.Cache
{
    public class HttpRuntimeWriter:ICacheWriter
    {
        public void AddCache(string key, object value, DateTime expTime)
        {
            HttpRuntime.Cache.Insert(key, value, null, expTime, TimeSpan.Zero);
        }

        public void AddCache(string key, object value)
        {
            HttpRuntime.Cache.Insert(key, value);
        }

        public object GetCache(string key)
        {
            return HttpRuntime.Cache.Get(key);
        }


        public T GetCache<T>(string key)
        {
            return (T)HttpRuntime.Cache.Get(key);
        }


        public void SetCache(string key, object value, DateTime expTime)
        {
            HttpRuntime.Cache.Remove(key);
            HttpRuntime.Cache.Insert(key, value,null, expTime,TimeSpan.Zero);
        }

        public void SetCache(string key, object value)
        {
            HttpRuntime.Cache.Remove(key);
            HttpRuntime.Cache.Insert(key, value);
        }
    }
}
