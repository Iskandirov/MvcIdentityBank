using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcIdentityBank.Models.DbModels
{
    public class CustomRoleManager : RoleManager<ApplicationRole>
    {
            public CustomRoleManager(RoleStore<ApplicationRole> store)
                        : base(store)
            { }
            public static CustomRoleManager Create(IdentityFactoryOptions<CustomRoleManager> options,
                                                    IOwinContext context)
            {
                return new CustomRoleManager(new
                        RoleStore<ApplicationRole>(context.Get<CustomContext>()));
            }
    }
}