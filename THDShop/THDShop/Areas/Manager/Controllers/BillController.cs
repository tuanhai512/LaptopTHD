using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace THDShop.Areas.Manager.Controllers
{
    public class BillController : Controller
    {
        QLLaptopShopEntities database = new QLLaptopShopEntities();

        // GET: Manager/BILL
        public ActionResult Index()
        {
            if (Session["IDQL"] != null || Session["IDNV"] != null)
            {
                return View(database.BILLs.ToList());
            }
            return Redirect("/LoginCustomer/LoginAccount");
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var hoadon = database.BILLs.Find(id);
            if (hoadon == null)
            {
                return HttpNotFound();
            }
            return View(hoadon);
        }
        public ActionResult Searchid(int id)
        {
            var list = database.BILLs.Where(p => p.ID==id).ToList();
            return View(list);
        }
    }
}