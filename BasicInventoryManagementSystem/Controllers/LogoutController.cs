﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasicInventoryManagementSystem.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Logout
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session["user"] = null;

            return RedirectToAction("../Home/Index");
        }
    }
}