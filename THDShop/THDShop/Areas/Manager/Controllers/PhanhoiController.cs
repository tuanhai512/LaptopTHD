using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace THDShop.Areas.Manager.Controllers
{
    public class PhanhoiController : Controller
    {
        QLLaptopShopEntities database = new QLLaptopShopEntities();
        public ActionResult Index()
        {
            return View(database.FEEDBACKs.ToList());

        }
        public ActionResult Create()
        {
            FEEDBACK fb = new FEEDBACK();
            return View(fb);
        }

        // POST: QuanLy/KhuyenMai/Create
        [HttpPost]
        public ActionResult Create(FEEDBACK fb)
        {   
            try
            {
                
                // TODO: Add insert logic here
                database.FEEDBACKs.Add(fb);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}




