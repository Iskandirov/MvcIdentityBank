using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcIdentityBank.Models.DbModels
{
    public class Account
    {
        public int ID{ get; set; }
        public string Number { get; set; }
        public decimal Qty { get; set; }
        public virtual CustomUser CustomUser { get; set; }
    }
}