using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyAspNetMvcApp.Models;
using System.Data.Entity;

namespace MyAspNetMvcApp.Controllers
{
    public class Book3Controller : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Book3
        public ActionResult Index()
        {
            //List<Book> books = (from book in db.Books select book).ToList();
            var books = db.Books.ToList();

            return View(books);

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book, HttpPostedFileBase fileUpload)
        {
            book.Picture = Gabs.Helpers.ImageUploadUtil.FileToByteArray(fileUpload);
            //book.ImgFilename = Gabs.Helpers.ImageUploadUtil.SaveToJpegFile(fileUpload, book.Title);
            db.Books.Add(book);
            db.SaveChanges();

            ViewBag.message = book.Title + " has been successfully added.";
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var book = db.Books.Find(id);
            return View(book);

        }
        
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Book3");

        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var book = db.Books.Find(Id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index", "Book3");
        }

    }
}