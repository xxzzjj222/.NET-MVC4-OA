using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OA.Model;
using System.Data.Entity;

namespace OA.EFDAL
{
    public class BaseDal<T> where T:class,new()
    {
        public DbContext db
        {
            get 
            {
                return DbContextFactory.GetCurrentDbContext();
            }
        }
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> GetEntities(Expression<Func<T,bool>> whereLambda)
        {
            return db.Set<T>().Where(whereLambda);
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orderLambda"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IQueryable<T> GetPageEntities<S>(int pageSize, int pageIndex,out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderLambda,bool isAsc)
        {
            total = db.Set<T>().Count();
            if (isAsc)
            {
                
                return db.Set<T>().Where(whereLambda)
                    .OrderBy(orderLambda)
                    .Skip(pageSize * (pageIndex - 1))
                    .Take(pageSize).AsQueryable();
            }
            else
            {
                return db.Set<T>().Where(whereLambda)
                    .OrderByDescending(orderLambda)
                    .Skip(pageSize * (pageIndex - 1))
                    .Take(pageSize).AsQueryable();
            }
        }
        #region cud
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T Add(T entity)
        {
            db.Set<T>().Add(entity);
            return entity;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return true;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(T entity)
        {
            db.Entry(entity).State = EntityState.Deleted;
            return true;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            T entity = db.Set<T>().Find(id);
            db.Set<T>().Remove(entity);
            return true;
        }
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int DeleteListByLogical(List<int> ids)
        {
            foreach (var id in ids)
            {
                T entity = db.Set<T>().Find(id);
                db.Entry(entity).Property("DelFlag").IsModified = true;
                db.Entry(entity).Property("DelFlag").CurrentValue = Model.DelFlagEnum.Deleted;
            }
            return ids.Count;
        }
        #endregion
    }
}
