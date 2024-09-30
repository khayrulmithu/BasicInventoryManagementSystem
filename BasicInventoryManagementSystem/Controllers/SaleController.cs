using BasicInventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasicInventoryManagementSystem.Controllers
{
    public class SaleController : Controller
    {
        InventoryEntities db = new InventoryEntities();
        // GET: Sale
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplaySale()
        {
            if (Session["user"] == null) return RedirectToAction("../Signin/Signin");

            List<Sale> list = db.Sales.OrderByDescending(x => x.id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult SaleProduct()
        {
            if (Session["user"] == null) return RedirectToAction("../Signin/Signin");

            List<string> list = db.Products.Select(x => x.Product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }

        [HttpPost]
        public ActionResult SaleProduct(Sale s)
        {
            db.Sales.Add(s);
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["user"] == null) return RedirectToAction("../Signin/Signin");

            Sale s = db.Sales.Where(x => x.id == id).SingleOrDefault();
            List<string> list = db.Products.Select(x => x.Product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View(s);
        }

        [HttpPost]
        public ActionResult Edit(int id, Sale pur)
        {
            Sale p = db.Sales.Where(x => x.id == id).SingleOrDefault();

            p.Sale_data = pur.Sale_data;
            p.Sale_prod = pur.Sale_prod;
            p.Sale_qnty = pur.Sale_qnty;
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            if (Session["user"] == null) return RedirectToAction("../Signin/Signin");

            Sale s = db.Sales.Where(x=>x.id==id).SingleOrDefault(); 
            return View(s);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["user"] == null) return RedirectToAction("../Signin/Signin");

            Sale s = db.Sales.Where(x => x.id == id).SingleOrDefault();
            return View(s);
        }

        [HttpPost]
        public ActionResult Delete(int id, Sale s)
        {
            Sale sale = db.Sales.Where(x => x.id == id).SingleOrDefault();
            db.Sales.Remove(sale);
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }
    }
}