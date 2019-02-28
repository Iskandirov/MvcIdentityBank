using AjaxSimpleHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxSimpleHelper.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string id)
        {
            return View("index",(object)id);
        }
        public ActionResult OrderedProducts(string id)
        {
            var orders = OrdersDb.GetOrders;
            if(!String.IsNullOrEmpty(id) && id != "All")
            {
                orders = orders.Where(o => o.Customer == id);
            }


            return PartialView(orders);
        }
    }
}