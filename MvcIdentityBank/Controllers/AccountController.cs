using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MvcIdentityBank.Models;
using MvcIdentityBank.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MvcIdentityBank.Controllers
{
    public class AccountController : Controller
    {
        //for Users managment
        public CustomUserManager UserManager
        {
            get => HttpContext.GetOwinContext().GetUserManager<CustomUserManager>();
        }
        //for register,login,logout ...& other identity operations
        private IAuthenticationManager AuthManager
        {
            get => HttpContext.GetOwinContext().Authentication;
        }
        public CustomSignInManager SignManager
        {
            get => HttpContext.GetOwinContext().Get<CustomSignInManager>();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            CustomContext cc = new CustomContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(cc));
            if (ModelState.IsValid)
            {
                var user = new CustomUser { UserName = model.UserName, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var role = roleManager.Roles.ToList().Single(r => r.Name == "user").Name;
                    await UserManager.AddToRoleAsync(user.Id, role );
                    await SignManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    return RedirectToAction("Profile", "Home");
                }
                //AddErrors(result);
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var customUser = await UserManager.FindAsync(model.Email, model.Password);
                if (customUser == null)
                {
                    ModelState.AddModelError("", "Password or Login is invalid!!!");
                }
                else
                {
                    var result = await UserManager.CreateIdentityAsync(customUser,
                        DefaultAuthenticationTypes.ApplicationCookie);
                    AuthManager.SignOut();
                    AuthManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, result);
                    if (String.IsNullOrEmpty(returnUrl))
                    {
                        return RedirectToAction("Profile", "Home");
                    }
                    else
                    {
                        return Redirect(returnUrl);

                    }
                }
            }
            ViewBag.returnUrl = returnUrl;
            return View(model);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            AuthManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase uploadFile)
        {
            if (uploadFile != null && uploadFile.ContentLength > 0)
            {
                string filePath = Path.Combine(Server.MapPath("/Temp"), Path.GetFileName(uploadFile.FileName));
                uploadFile.SaveAs(filePath);
                //using (UserContext db = new UserContext())
                //{
                //    Update(new object[16], db);
                //}
            }
            
            return View();
            
        }
    //    public static void Update<TEntity>(TEntity entity, DbContext context)
    //where TEntity : class
    //    {
    //        context.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));

    //        context.Entry<TEntity>(entity).State = EntityState.Modified;
    //        context.SaveChanges();
    //    }
    }
}
