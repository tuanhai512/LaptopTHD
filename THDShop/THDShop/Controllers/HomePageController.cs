using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THDShop.ViewModel;

namespace THDShop.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        QLLaptopShopEntities _db = new QLLaptopShopEntities();
        public ActionResult Index()
        {
            var query = _db.PRODUCTS.OrderByDescending(x => x.NAME);
            return View(query);
        }
        public ActionResult Details(int id)
        {
            return View(_db.PRODUCTS.Where(s => s.ID == id).FirstOrDefault());
        }
        public ActionResult Product()
        {
            var query = _db.PRODUCTS.OrderByDescending(x => x.NAME);
            return View(query);
        }
        public ActionResult Voucher()
        {
            var query = _db.GIFT.OrderByDescending(x => x.ID);
            return View(query);
        }
    }
}