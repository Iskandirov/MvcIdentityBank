﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcIdentityBank.Models
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
        public string Status { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
    }


    class UserContext : DbContext
    {
        public UserContext()
            : base("CutomConnectionString")
        { }

        public DbSet<User> Users { get; set; }
    }
}