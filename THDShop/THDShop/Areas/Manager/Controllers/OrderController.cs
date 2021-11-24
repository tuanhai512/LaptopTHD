using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace THDShop.Areas.Manager.Controllers
{
    public class OrderController : Controller
    {
        // GET: Manager/Order
        public ActionResult Index()
        {
            return View();
        }
    }
}