using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA.Commom;
using System.Configuration;

namespace SugarDao
{
    public class DbContextFactory
    {
        public DbContextFactory()
        {
            Db = new SqlSugarClient(new ConnectionConfig()
                {
                    ConnectionString = ConnectionString,
                    DbType = DbType,
                    IsAutoCloseConnection = IsAutoCloseConnection,
                    IsShardSameThread = true,
                    MoreSettings = new ConnMoreSettings()
                    {
                        IsAutoRemoveDataCache = true
                    }
                });
        }
        //SqlSugar对象
        public SqlSugarClient Db;

        //连接字符串
        private  string _connectionString;
        public  string ConnectionString { 
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = System.Configuration.ConfigurationManager.AppSettings["sqlProvider"];
                }
                return _connectionString;
            }
        }
        //数据库类型
        private  DbType _dbType;
        public  DbType DbType
        {
            get
            {
                if (_dbType == null)
                {
                    _dbType= (DbType)Enum.Parse(typeof(DbType), System.Configuration.ConfigurationManager.AppSettings["sqlType"]);
                }
                return _dbType;
            }
        }
        //自动释放数据务，如果存在事务，在事务结束后释放
        private  bool _isAutoCloseConnection;
        public  bool IsAutoCloseConnection
        {
            get
            {
                if (_isAutoCloseConnection == null)
                {
                    _isAutoCloseConnection= bool.Parse(System.Configuration.ConfigurationManager.AppSettings["isAutoCloseConnection"]);
                }
                return _isAutoCloseConnection;
            }
        }
    }
}
