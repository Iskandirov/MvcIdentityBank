using Microsoft.AspNet.Identity.EntityFramework;
using MvcIdentityBank.Models.DbModels;
using System;
using System.Data.Entity;

namespace MvcIdentityBank
{
    public class CustomContext : IdentityDbContext<CustomUser>
    {
        public CustomContext() : base("CutomConnectionString")
        {
            Database.SetInitializer<CustomContext>(new DropCreateDatabaseAlways<CustomContext>());
        }
        public static CustomContext Create()
        {
            return new CustomContext();
        }
        public virtual DbSet<Account> Accounts { get; set; }
    }
}