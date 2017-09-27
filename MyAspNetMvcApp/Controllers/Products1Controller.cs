﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyAspNetMvcApp.Models;
using MyAspNetMvcApp.Models.OrderApp;

namespace MyAspNetMvcApp.Controllers
{
    [Authorize]
    public class Products1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
         
        // GET: Products1
        [AllowAnonymous]
        public ActionResult Index(string keyword, int sort = 0)
        {
            List<Product> products;
            if (string.IsNullOrWhiteSpace(keyword))
            {
               products  = db.Products.ToList();
            }
            else
            {
                products = db.Products.Where(x => x.Name.Contains(keyword)).ToList();
            }

            if(sort == 1)
            {
                products = products.OrderBy(x => x.Price).ToList();
            }
            else if(sort == 2)
            {
                products = products.OrderBy(x => x.Name).ToList();
            }

            return View(products);
        }

        public ActionResult Bootstrap()
        {
            return View();
        }

        // GET: Products1/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            Product product = db.Products.Find(id);
            return View(product);
        }

        // GET: Products1/Create
        [Authorize(Roles = "staff")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase FileUpload)
        {
            product.Picture = Gabs.Helpers.ImageUploadUtil.FileToByteArray(FileUpload);
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Products1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,CategoryId,Price,Picture")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}