using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcIdentityBank.Models.DbModels
{
    public class CustomRole : IdentityRole
    {
        public CustomRole() { }

        public string Description { get; set; }
    }
}