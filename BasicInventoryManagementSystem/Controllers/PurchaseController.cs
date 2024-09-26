using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BasicInventoryManagementSystem.Models;

namespace BasicInventoryManagementSystem.Controllers
{
    public class PurchaseController : Controller
    {
        InventoryEntities db = new InventoryEntities();
        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplayPurchase()
        {
            List<Purchase> list = db.Purchases.OrderByDescending(x=>x.id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult PurchaseProduct()
        {
            List<string> list = db.Products.Select(x=>x.Product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }

        [HttpPost]
        public ActionResult PurchaseProduct(Purchase pur)
        {
            db.Purchases.Add(pur);
            db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }



    }
}