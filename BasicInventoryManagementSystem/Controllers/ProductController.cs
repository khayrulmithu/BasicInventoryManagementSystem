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
            if (Session["user"] == null) return RedirectToAction("../Signin/Signin");

            List<Product> list = db.Products.OrderByDescending(x=>x.id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            if (Session["user"] == null) return RedirectToAction("../Signin/Signin");

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

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            if (Session["user"] == null) return RedirectToAction("../Signin/Signin");

            Product pr = db.Products.Where(x => x.id == id).SingleOrDefault();
            return View(pr);
        }

        [HttpPost]
        public ActionResult UpdateProduct(int id, Product pro)
        {
            Product pr = db.Products.Where(x => x.id == id).SingleOrDefault();
            pr.Product_name = pro.Product_name;
            pr.Product_qnty = pro.Product_qnty;
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }

        [HttpGet]
        public ActionResult ProductDetails(int id)
        {
            if (Session["user"] == null) return RedirectToAction("../Signin/Signin");

            Product pr = db.Products.Where(x => x.id == id).SingleOrDefault();
            return View(pr);

        }


        [HttpPost]
        public ActionResult ProductDetails(int id, Product pro)
        {
            Product pr = db.Products.Where(x => x.id == id).SingleOrDefault();
            pr.Product_name=pro.Product_name;
            pr.Product_qnty=pro.Product_qnty;
            db.SaveChanges();
            return View(pr);

        }

        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            if (Session["user"] == null) return RedirectToAction("../Signin/Signin");

            Product pro = db.Products.Where(x => x.id == id).SingleOrDefault();
            return View(pro);

        }


        [HttpPost]
        public ActionResult DeleteProduct(int id, Product pro)
        {
            db.Products.Remove( db.Products.Where(x => x.id == id).SingleOrDefault());
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");

        }








    }

}