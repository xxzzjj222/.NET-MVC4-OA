using Memcached.ClientLibrary;
using OA.BLL;
using OA.Commom.Cache;
using OA.IBLL;
using OA.Model;
using OA.UIPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA.UIPortal.Controllers
{
    [LoginVerifyFilter(IsCheck = false)]
    public class UserLoginController : Controller
    {
       
        private IUserInfoService UserInfoService { get; set; }
        //
        // GET: /UserLogin/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProcessLogin(string UserName,string Password)
        {
            UserInfo loginUser=UserInfoService.GetEntities(u => u.Name == UserName).FirstOrDefault();
            if (loginUser != null && loginUser.Password == Password)
            {
                string userLoginId = Guid.NewGuid().ToString();
                Response.Cookies["userLoginId"].Value = userLoginId;
                CacheHelper.AddCache(userLoginId, loginUser, DateTime.Now.AddMinutes(20));
                //Session["loginUser"] = loginUser;
                return Content("succeed");
            }
            else
            {
                return Content("failed");
            }
        }
    } 
}
