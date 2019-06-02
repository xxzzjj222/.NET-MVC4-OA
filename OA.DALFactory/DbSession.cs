using OA.EFDAL;
using OA.IDAL;
using OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.DALFactory
{
    public partial  class DbSession : IDbSession
    {
        //public IUserInfoDal UserInfoDal
        //{
        //    get
        //    {
        //        return StaticDalFactory.GetUserInfoDal();
        //    }
        //}
        //public IOrderInfoDal OrderInfoDal
        //{
        //    get
        //    {
        //        return StaticDalFactory.GetOrderInfoDal();
        //    }
        //}

        public int SaveChanges()
        {
            return DbContextFactory.GetCurrentDbContext().SaveChanges();
        }
    }
}
