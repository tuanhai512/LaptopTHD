using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THDShop.ViewModel.Product;

namespace THDShop.Controllers
{
    public class HomeUserController : Controller
    {
        // GET: HomeUser
        QLLaptopShopEntities _db = new QLLaptopShopEntities();

        public HomeUserController()
        {
            ProductSingleton.Instance.Init(_db);
        }

        public ActionResult Index()
        {
            var query = _db.PRODUCTS.OrderByDescending(x => x.NAME);
            return View(query);

        }
        public ActionResult Details(int id)
        {
            return View(_db.PRODUCTS.Where(s => s.ID == id).FirstOrDefault());
        }

    }
}