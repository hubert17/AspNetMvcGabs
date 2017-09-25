using MyAspNetMvcApp.Models;
using MyAspNetMvcApp.Models.OrderApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAspNetMvcApp.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(int productId, int quantity)
        {
            Order myOrder = new Order();
            var myOrderItems = new OrderItem();

            var currentOrder = db.Orders.Where(x => x.UserName == User.Identity.Name && x.Status == -1).FirstOrDefault();
            if(currentOrder == null)
            {
                myOrder.UserName = User.Identity.Name;
                myOrder.OrderDate = DateTime.Now;
                myOrder.Status = -1;
                db.Orders.Add(myOrder);
                myOrderItems.OrderId = myOrder.Id;
            }
            else
            {
                myOrderItems.OrderId = currentOrder.Id;
            }

            myOrderItems.ProductId = productId;
            myOrderItems.Quantity = quantity;

            db.OrderItems.Add(myOrderItems);
            db.SaveChanges();

            TempData["MessageBox"] = "Added to cart.";
            return RedirectToAction("Index", "Products");
        }
    }
}