using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace THDShop.Areas.Manager.Controllers
{
    public class ReportController : Controller
    {
        QLLaptopShopEntities database = new QLLaptopShopEntities();

        // GET: Manager/Report
        public ActionResult Index()
        {
            return View(database.REPORTs.ToList());
        }

        // GET: Manager/Report/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Manager/Report/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manager/Report/Create
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

        // GET: Manager/Report/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Manager/Report/Edit/5
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

        // GET: Manager/Report/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Manager/Report/Delete/5
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
        //public ActionResult Searchday(DateTime day)
        ////{
        ////    day = day.Day.;
        //// var list = database.REPORTs.Where(p => p.DATE.Day==day ).ToList();
        ////    return View(list);
        //}
    }
}
