﻿//using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongodbDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //var mongoDbHelper = new MongoDbHelper("MongoDbConnectionString", "LogDB");

            //mongoDbHelper.CreateCollection<SysLogInfo>("SysLog1", new[] { "LogDT" });

            //mongoDbHelper.Find<SysLogInfo>("SysLog1", t => t.Level == "Info");

            //int rsCount = 0;
            //mongoDbHelper.FindByPage<SysLogInfo, SysLogInfo>("SysLog1", t => t.Level == "Info", t => t, 1, 20, out rsCount);

            //mongoDbHelper.Insert<SysLogInfo>("SysLog1", new SysLogInfo { LogDT = DateTime.Now, Level = "Info", Msg = "测试消息" });

            //mongoDbHelper.Update<SysLogInfo>("SysLog1", new SysLogInfo { LogDT = DateTime.Now, Level = "Error", Msg = "测试消息2" }, t => t.LogDT == new DateTime(1900, 1, 1));

            //mongoDbHelper.Delete<SysLogInfo>(t => t.Level == "Info");

            //mongoDbHelper.ClearCollection<SysLogInfo>("SysLog1");
        }
    }
}
