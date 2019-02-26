using Microsoft.AspNet.Identity.EntityFramework;
using MvcIdentityBank.Models.DbModels;
using System;
using System.Collections.Generic;

namespace MvcIdentityBank
{
    public class CustomUser : IdentityUser
    {
        public string SkinColor { get; set; }
        public DateTime LastVist { get; set; }
        public virtual ICollection<Account> Account { get; set; }
    }
}