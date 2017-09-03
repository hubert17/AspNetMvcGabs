using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyAspNetMvcApp.Models;

namespace MyAspNetMvcApp.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Send(Email mail, HttpPostedFileBase Attachment)
        {
            var attachment = Gabs.Helpers.EmailUtil.FileToAttachment(Attachment);
            TempData["msg"] = Gabs.Helpers.EmailUtil.SendEmail(mail.MailTo, mail.Subject, mail.Message, attachment);

            return RedirectToAction("Index");
        }
    }
}