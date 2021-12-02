using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace THDShop.Areas.Manager.Controllers
{
    public class BillController : Controller
    {
        QLLaptopShopEntities database = new QLLaptopShopEntities();

        // GET: Manager/BILL
        public ActionResult Index()
        {

            return View(database.BILL.ToList());
        }


        public ActionResult Details(int id)
        {
            return View(database.BILL.Where(s => s.ID == id).FirstOrDefault());
        }

    }
}