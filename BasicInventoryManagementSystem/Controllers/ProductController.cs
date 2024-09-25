using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BasicInventoryManagementSystem.Models;

namespace BasicInventoryManagementSystem.Controllers
{
    public class ProductController : Controller
    {
        InventoryEntities db = new InventoryEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplayProduct()
        {
            List<Product> list = db.Products.OrderByDescending(x=>x.id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(Product pro)
        {
            if (pro.Product_name != null & pro.Product_qnty!=null)
            {
                db.Products.Add(pro);
                db.SaveChanges();
                return RedirectToAction("DisplayProduct");
            }

            return View();
        }
    }

}