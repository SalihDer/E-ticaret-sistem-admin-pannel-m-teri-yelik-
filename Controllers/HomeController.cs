using lsad.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace lsad.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        { 
            
            return View(db.Categories.ToList());
        }

        public ActionResult Details(int ProductId)
        {
            var product = db.Products.Find(ProductId);
            if (product == null)
            {
                return HttpNotFound();
            }
            Session["ProductId"] = ProductId;
            return View(product);
        }
        [Authorize]
        
    public ActionResult Order()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Order(string Adress, string PhoneNumber)
        {

            var UserId = User.Identity.GetUserId();
            var ProductId = (int)Session["ProductId"];
            var product = new SepeteEkle();
            product.UserId = UserId;
            product.ProductId = ProductId;
            product.OrderDate = DateTime.Now;
            product.PhoneNumber = PhoneNumber;
            product.Adress = Adress;
            db.SepeteEkles.Add(product);
            db.SaveChanges();
            ViewBag.Result = "Done";

        
            return View();
        }
        [Authorize]
        public ActionResult OrdersByUser()
        {
            var UserId = User.Identity.GetUserId();
            var Products = db.SepeteEkles.Where(a => a.UserId == UserId);
            return View(Products.ToList());
        }

        [Authorize]
        public ActionResult DetailsOfOrder (int id)
        {
            var product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);

        }
        public ActionResult Edit(int id)
        {
            var product = db.SepeteEkles.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        
        public ActionResult Edit(SepeteEkle product)
        {
            if (ModelState.IsValid)
            {
                product.OrderDate = DateTime.Now;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("OrdersByUser");
            }
            return View(product);
        }

        public ActionResult Delete(int id)
        {
            
            var product = db.SepeteEkles.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Categories/Delete/5
        [HttpPost]
        public ActionResult Delete(SepeteEkle product)
        {
            var myproduct = db.SepeteEkles.Find(product.Id);
            db.SepeteEkles.Remove(myproduct);
            db.SaveChanges();
            return RedirectToAction("OrdersByUser");
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}