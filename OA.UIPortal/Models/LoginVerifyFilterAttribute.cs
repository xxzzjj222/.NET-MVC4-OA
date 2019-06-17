using OA.Commom.Cache;
using OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA.UIPortal.Models
{
    public class LoginVerifyFilterAttribute : ActionFilterAttribute
    {
        public bool IsCheck { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (IsCheck)
            {
                if (filterContext.HttpContext.Request.Cookies["userLoginId"] == null)
                {
                    filterContext.HttpContext.Response.Redirect("/UserLogin/Index");
                    return;
                }
                string userLoginId = filterContext.HttpContext.Request.Cookies["userLoginId"].Value;
                UserInfo loginUser = CacheHelper.GetCache(userLoginId) as UserInfo;
                if (loginUser == null)
                {
                    filterContext.HttpContext.Response.Redirect("/UserLogin/Index");
                    return;
                }
                else
                {
                    CacheHelper.SetCache(userLoginId, loginUser, DateTime.Now.AddMinutes(20));
                }
            }
        }
    }
}