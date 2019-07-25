using OA.DALFactory;
using OA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OA.BLL
{
    public abstract class BaseService<T> where T:class,new()
    {
        public IDbSession dbSession = DbSessionFactory.GetCurrentDbSession();
        public IBaseDal<T> CurrentDal { get; set; }

        public BaseService()
        {
            GetCurrentDal();
        }
        public abstract void GetCurrentDal();
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentDal.GetEntities(whereLambda);
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
        public IQueryable<T> GetPageEntities<S>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderLambda, bool isAsc)
        {
            return CurrentDal.GetPageEntities<S>(pageSize,pageIndex,out total,whereLambda,orderLambda,isAsc);
        }
        #region cud
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T Add(T entity)
        {
            CurrentDal.Add(entity);
            dbSession.SaveChanges();
            return entity;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(T entity)
        {
            CurrentDal.Update(entity);
            return dbSession.SaveChanges() > 0;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(T entity)
        {
            CurrentDal.Delete(entity);
            return dbSession.SaveChanges() > 0;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            CurrentDal.Delete(id);
            return dbSession.SaveChanges() > 0;
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int DeleteList(List<int> ids)
        {
            foreach (var id in ids)
            {
                CurrentDal.Delete(id);
            }
            return dbSession.SaveChanges();
        }

        public int DeleteListByLogical(List<int> ids)
        {
            CurrentDal.DeleteListByLogical(ids);
            return dbSession.SaveChanges();
        }
        #endregion
    }
}
