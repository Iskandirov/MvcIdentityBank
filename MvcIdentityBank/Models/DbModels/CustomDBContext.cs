using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcIdentityBank.Models.DbModels
{
    public class CustomDBContext : IdentityDbContext<CustomUser>
    {
        public CustomDBContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static CustomDBContext Create()
        {
            return new CustomDBContext();
        }
    }
}