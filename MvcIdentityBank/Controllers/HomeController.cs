using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcIdentityBank.Models.ViewModels;

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
            IList<string> roles = new List<string> { "Роль не определена" };
            CustomUserManager userManager = HttpContext.GetOwinContext()
                                                    .GetUserManager<CustomUserManager>();
            CustomUser user = userManager.FindByEmail(User.Identity.Name);
            if (user != null)
                roles = userManager.GetRoles(user.Id);
            return View(roles);
        }

        public ActionResult Messages()
        {
            ViewBag.Message = "application description page.";
            return View();
        }
        public ActionResult Friends()
        {
            IList<string> roles = new List<string> { "Роль не определена" };
            CustomUserManager userManager = UserManager;
            CustomUser user = userManager.FindByEmail(User.Identity.Name);
            if (user != null)
            {
                roles = userManager.GetRoles(user.UserName);
            }
            ViewBag.Role = "test";
            return View();
        }
    }
}