using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace THDShop.Areas.Manager.Controllers
{
    public class MyGiftController : Controller
    {
        QLLaptopShopEntities database = new QLLaptopShopEntities();

        // GET: Manager/MyGift
        public ActionResult Index()
        {
            CUSTOMER cUSTOMER = database.CUSTOMERs.FirstOrDefault();
            Session["EMAIL"] = cUSTOMER.EMAIL;
            var detailMygift = database.MYGIFTs.Where(m => m.ID == cUSTOMER.ID).FirstOrDefault();
            return View(detailMygift);
        }

        // GET: Manager/MyGift/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Manager/MyGift/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manager/MyGift/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Manager/MyGift/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Manager/MyGift/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Manager/MyGift/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Manager/MyGift/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
