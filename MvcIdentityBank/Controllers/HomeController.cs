using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcIdentityBank.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public new ActionResult Profile()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult MainPage()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Messages()
        {
            ViewBag.Message = "application description page.";

            return View();
        }
        public ActionResult Friends()
        {
            ViewBag.Message = "application description page.";

            return View();
        }
    }
}