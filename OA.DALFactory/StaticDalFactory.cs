using OA.EFDAL;
using OA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Configuration;
using System.Web;

namespace OA.DALFactory
{
    public partial class StaticDalFactory
    {
        public static string assembly = System.Configuration.ConfigurationManager.AppSettings["CurrentDalAssembly"];
        //public static IUserInfoDal GetUserInfoDal()
        //{
        //    IUserInfoDal userInfoDal = HttpRuntime.Cache["UserInfoDal"] as IUserInfoDal;
        //    if (userInfoDal == null)
        //    {
        //        userInfoDal = Assembly.Load(assembly).CreateInstance(assembly + ".UserInfoDal") as IUserInfoDal;
        //        HttpRuntime.Cache["UserInfoDal"] = userInfoDal;
        //    }
        //    return userInfoDal;
        //}
        //public static IOrderInfoDal GetOrderInfoDal()
        //{
        //    IOrderInfoDal orderInfoDal = HttpRuntime.Cache["OrderInfoDal"] as IOrderInfoDal;
        //    if (orderInfoDal == null)
        //    {
        //        orderInfoDal = Assembly.Load(assembly).CreateInstance(assembly + ".OrderInfoDal") as IOrderInfoDal;
        //        HttpRuntime.Cache["OrderInfoDal"] = orderInfoDal;
        //    }
        //    return orderInfoDal;
        //}

        //public static IBaseDal<T> GetEntityDal()
        //{
        //    IBaseDal<T> entityDal = HttpRuntime.Cache[typeof(T).Name + "Dal"] as IBaseDal<T>;
        //    if (entityDal == null)
        //    {
        //        entityDal = Assembly.Load(assembly).CreateInstance(assembly + "." + typeof(T).Name + "Dal") as IBaseDal<T>;
        //        HttpRuntime.Cache[typeof(T).Name + "Dal"] = entityDal;
        //    }
        //    return entityDal;
        //}
    }
}
