using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
//using MongoDB.Driver;

namespace MongodbDemo
{
    public class MongoManager
    {
        //private static string MongoConnstr = System.Configuration.ConfigurationManager.AppSettings["mongo"];
        //private static MongoClient _client;

        //static MongoManager()
        //{
        //    CreateManager();
        //}

        //public static MongoClient GetClient()
        //{
        //    if (_client != null)
        //    {
        //        _client = CreateManager(MongoConnstr);
        //    }
        //    return _client;
        //}

        //private static void CreateManager()
        //{
        //    _client = CreateManager(MongoConnstr);
        //}

        //private static MongoClient CreateManager(string connStr)
        //{
        //    return new MongoClient(connStr);
        //}
        ////获取database
        //public static IMongoDatabase GetDatabase(string dbname)
        //{
        //    if (!_client.ListDatabases().ToList().Select(db => db.GetValue("name").AsString).Contains(dbname))
        //    {
        //        throw new Exception("database " + dbname + " not exist");
                
        //    }
        //    return _client.GetDatabase(dbname);
        //}
        //////获取collection
        ////public static IMongoCollection GetDocument(string name)
        ////{
        ////    if(!)
        ////}
    }
}
