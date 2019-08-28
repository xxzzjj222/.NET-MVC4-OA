using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;
using System.Linq.Expressions;

namespace SugarDao
{
    public class BaseDal<T> where T:class,new()
    {
        public BaseDal()
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

        #region SqlSugarClient参数
        //连接字符串
        private string _connectionString;
        public string ConnectionString
        {
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
        private DbType _dbType;
        public DbType DbType
        {
            get
            {
                _dbType = (DbType)Enum.Parse(typeof(DbType), System.Configuration.ConfigurationManager.AppSettings["sqlType"]);
                return _dbType;
            }
        }
        //自动释放数据务，如果存在事务，在事务结束后释放
        private bool _isAutoCloseConnection;
        public bool IsAutoCloseConnection
        {
            get
            {
                _isAutoCloseConnection = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["isAutoCloseConnection"]);
                return _isAutoCloseConnection;
            }
        } 
        #endregion

        //SqlSugar对象
        public SqlSugarClient Db;
        //SimpleClient对象
        public SimpleClient<T> CurrentDb
        {
            get 
            {
                return new SimpleClient<T>(Db);
            }
        }
        #region R
        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> GetEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {
            return Db.Queryable<T>().Where(whereLambda).ToList().AsQueryable();
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="total"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orderLambda"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public virtual IQueryable<T> GetPageEntities<S>(int pageSize, int pageIndex, out int total, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, S>> orderLambda, bool isAsc)
        {
            total = Db.Queryable<T>().Count();
            return Db.Queryable<T>().Where(whereLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList().AsQueryable();
        } 
        #endregion
        #region CUD
        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Delete(int id)
        {
            return CurrentDb.DeleteById(id);
        }
        /// <summary>
        /// 根据实体删除
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual bool Delete(T obj)
        {
            return CurrentDb.Delete(obj);
        }
        //批量逻辑删除
        public virtual int DeleteListByLogical(List<int> ids)
        {
            return Db.Deleteable<T>().In(ids).ExecuteCommand();
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual bool Update(T obj)
        {
            return CurrentDb.Update(obj);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual T Add(T obj)
        {
            return CurrentDb.AsInsertable(obj).ExecuteReturnEntity();
            //return Db.Insertable<T>(obj).ExecuteReturnEntity();
        } 
        #endregion
    }
}
