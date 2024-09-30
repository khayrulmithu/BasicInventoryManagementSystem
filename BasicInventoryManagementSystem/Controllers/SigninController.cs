using BasicInventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace BasicInventoryManagementSystem.Controllers
{
    public class SigninController : Controller
    {
        public int user;
        // GET: Signin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(Signin model)
        {
            string email = model.Email;

            string pass = model.Password;

            Console.WriteLine("Email = " + email);

            if(email=="admin@gmail.com" && pass=="1234")
            {
                Session["user"] = 1;

                return RedirectToAction("../Product/DisplayProduct");
            }

            else
            {
                ViewBag.ErrorMessage = "Wrong Email or Password";

                return View();
            }
            
        }
    }
}