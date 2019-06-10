using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA.UIPortal.Models
{
    public class LoginVerifyFilterAttribute:ActionFilterAttribute
    {
        public bool IsCheck { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (IsCheck)
            {
                if (filterContext.HttpContext.Session["loginUser"] == null)
                {
                    filterContext.HttpContext.Response.Redirect("/UserLogin/Index");
                }
            }
        }
    }
}