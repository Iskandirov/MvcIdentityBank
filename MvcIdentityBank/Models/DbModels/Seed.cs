using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using MvcIdentityBank.Models.DbModels;

namespace MvcIdentityBank.Models
{
    public class AppDbInitializer : DropCreateDatabaseAlways<CustomContext>
    {
        protected override void Seed(CustomContext context)
        {
            //var RoleManager = HttpContext.GetOwinContext().Get<CustomRoleManager>();
            //const string roleName = "admin";

            //var Role = RoleManager.FindByName(roleName);
            //if (Role == null)
            //{
            //    Role = new CustomRole();
            //    Role.Id = "1";
            //    Role.Name = roleName;

            //    var roleresult = RoleManager.Create(Role);
            //}

            //base.Seed(context);
        }
    }
}
