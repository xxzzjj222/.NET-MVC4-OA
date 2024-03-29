﻿using OA.BLL;
using OA.Commom.Cache;
using OA.IBLL;
using OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OA.UIPortal.Controllers
{
    public class UserInfoController : Controller
    {
        IUserInfoService UserInfoService { get; set; }
        //
        // GET: /UserInfo/

        public ActionResult Index()
        {
            //throw new Exception("出错啦");
            string aa=CacheHelper.GetCache("verifyCode").ToString();
            ViewData.Model = UserInfoService.GetEntities(u=>true);
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                UserInfoService.Add(userInfo);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Test()
        {
            return View();
        }

        public ActionResult Delete(int ID)
        {
            UserInfoService.Delete(ID);
            return RedirectToAction("Index");
        }
    }
}
