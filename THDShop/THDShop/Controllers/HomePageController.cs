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
            var query = _db.GIFTs.OrderByDescending(x => x.ID);
            return View(query);
        }
        [HttpPost]
        public ActionResult AddListGift(string id)
        {
            //id = "SINHVIEN";
            var entity = _db.GIFTs.SingleOrDefault(s=>s.ID==id); 
            var check = _db.MYGIFTs.Where(s => s.IDGIFT == id).FirstOrDefault();

            int idcus = (int)Session["ID"];
            //if (check == null)
            //{
                if (Session["ID"] != null)
                {
                    var myGift = new MYGIFT()
                    {
                        IDGIFT = entity.ID,
                        IDCUS = (int)Session["ID"],
                      };
                    _db.MYGIFTs.Add(myGift);
                    _db.SaveChanges();
                    return RedirectToAction("MyGift", "LoginCustomer");
                }
                else
                {
                    return RedirectToAction("LoginAccount", "LoginCustomer");

                }
            //}
            //return RedirectToAction("Index", "HomeUser");
        }
    }
}