using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA.Model;
using OA.IDAL;

namespace SugarDao
{
    public class UserInfoDal:BaseDal<UserInfo>,IUserInfoDal
    {
        public override IQueryable<UserInfo> GetEntities(System.Linq.Expressions.Expression<Func<UserInfo, bool>> whereLambda)
        {
            return Db.Queryable<UserInfo>().Where(whereLambda).Select(u => new UserInfo() { ID = u.ID, Name = u.Name, Password = u.Password }).ToList().AsQueryable();
        }
        public override IQueryable<UserInfo> GetPageEntities<S>(int pageSize, int pageIndex, out int total, System.Linq.Expressions.Expression<Func<UserInfo, bool>> whereLambda, System.Linq.Expressions.Expression<Func<UserInfo, S>> orderLambda, bool isAsc)
        {
            total = CurrentDb.Count(whereLambda);
            return Db.Queryable<UserInfo>().Where(whereLambda).Skip(pageSize * (pageIndex * pageSize)).Take(pageSize).Select(u => new UserInfo() { ID = u.ID, Name = u.Name, Password = u.Password }).ToList().AsQueryable();
        }
    }
}
