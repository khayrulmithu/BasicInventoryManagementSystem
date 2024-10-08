﻿using System;
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
            if (Session["user"] == null) return RedirectToAction("../Signin/Signin");

            List<Purchase> list = db.Purchases.OrderByDescending(x=>x.id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult PurchaseProduct()
        {
            if (Session["user"] == null) return RedirectToAction("../Signin/Signin");

            List<string> list = db.Products.Select(x=>x.Product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }

        [HttpPost]
        public ActionResult PurchaseProduct(Purchase p)
        {
            //db.Purchases.Add(pur);
            ////db.SaveChanges();
            //return RedirectToAction("DisplayPurchase");

            try
            {
                db.Purchases.Add(p);
                db.SaveChanges();
                return RedirectToAction("DisplayPurchase");
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
                return View("Error"); // Or any other appropriate error handling
            }

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["user"] == null) return RedirectToAction("../Signin/Signin");

            Purchase p = db.Purchases.Where(x => x.id == id).SingleOrDefault();
            List<string> list = db.Products.Select(x => x.Product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(int id, Purchase pur)
        {
            Purchase p = db.Purchases.Where(x => x.id == id).SingleOrDefault();

            //DateTime date = new DateTime();

            try
            {
                p.Purchase_data = pur.Purchase_data;
                p.Purchase_prod = pur.Purchase_prod;
                p.Purchase_qnty = pur.Purchase_qnty;
                db.SaveChanges();
                return RedirectToAction("DisplayPurchase");
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View("Error");
            }
            
            
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            if (Session["user"] == null) return RedirectToAction("../Signin/Signin");

            Purchase p = db.Purchases.Where(x => x.id == id).SingleOrDefault();
            return View(p);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["user"] == null) return RedirectToAction("../Signin/Signin");

            Purchase p = db.Purchases.Where(x => x.id == id).SingleOrDefault();
            return View(p);
        }

        [HttpPost]
        public ActionResult Delete(int id, Purchase p)
        {
            Purchase pr = db.Purchases.Where(x => x.id == id).SingleOrDefault();
            db.Purchases.Remove(pr);
            db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }



    }
}