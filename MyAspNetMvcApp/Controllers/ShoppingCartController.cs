using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyAspNetMvcApp.Models.OrderApp;
using MyAspNetMvcApp.Models;

namespace MyAspNetMvcApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(int productId, int quantity)
        {
            Order currentOrder = db.Orders.Where(x => x.UserName == User.Identity.Name && x.Status == -1).FirstOrDefault();

            Order myOrders;
            var myItem = new OrderItem();

            if (currentOrder == null)
            {
                myOrders = new Order();
                myOrders.OrderDate = DateTime.Now;
                myOrders.UserName = User.Identity.Name;
                myOrders.Status = -1;
                myItem.OrderId = myOrders.Id;
                db.Orders.Add(myOrders);
            }
            else
            {
                myItem.OrderId = currentOrder.Id;
            }


            myItem.ProductId = productId;
            myItem.Quantity = quantity;

            db.OrderItems.Add(myItem);
            db.SaveChanges();

            return RedirectToAction("Index", "StoreProducts");
        }
    }
}