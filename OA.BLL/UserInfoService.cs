using OA.DALFactory;
using OA.EFDAL;
using OA.IBLL;
using OA.IDAL;
using OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OA.BLL
{
    public partial class UserInfoService:BaseService<UserInfo>,IUserInfoService
    {
        //public override void GetCurrentDal()
        //{
        //    base.CurrentDal = dbSession.UserInfoDal;
        //}
    }
}
