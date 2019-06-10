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
        //
        // GET: /UserLogin/
        public ActionResult Index()
        {
            return View();
        }
        [LoginVerifyFilter(IsCheck=true)]
        public ActionResult ProcessLogin(string Name)
        {
            Session["loginUser"] = Name;
            return Content("ok");
        }
    } 
}
