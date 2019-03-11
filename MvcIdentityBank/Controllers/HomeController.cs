using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MvcIdentityBank.Controllers
{
    public class HomeController : Controller
    {
        public CustomUserManager UserManager
        {
            get => HttpContext.GetOwinContext().GetUserManager<CustomUserManager>();
        }

        //for register,login,logout ...& other identity operations
        private IAuthenticationManager AuthManager
        {
            get => HttpContext.GetOwinContext().Authentication;
        }


        public ActionResult Index()
        {
            return View();
        }

        public new ActionResult Profile()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Messages()
        {
            ViewBag.Message = "application description page.";

            return View();
        }
        public ActionResult Friends()
        {
            //List<string> list = new List<string>();
            //list = UserManager.Users.ToList<string> ;

            ViewBag.Message = "application description page.";

            return View();
        }
    }
}