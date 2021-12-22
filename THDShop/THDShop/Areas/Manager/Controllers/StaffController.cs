using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace THDShop.Areas.Manager.Controllers
{
    public class StaffController : Controller
    {
        // GET: Manager/Staff
        QLLaptopShopEntities _db = new QLLaptopShopEntities();

        public ActionResult Index()
        {

            return View(_db.STAFFs.ToList());
        }


        public ActionResult Details(int id)
        {
            return View(_db.STAFFs.Where(s => s.ID == id).FirstOrDefault());
        }


        public ActionResult Create()
        {
            STAFF user = new STAFF();
            return View(user);
        }


        [HttpPost]
        public ActionResult Create(STAFF staff)
        {
            try
            {
                if (ModelState.IsValid)
                // TODO: Add insert logic here
                {
                    _db.STAFFs.Add(staff);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(staff);
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            return View(_db.STAFFs.Where(s => s.ID == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Edit(STAFF staff, int id)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    _db.Entry(staff).State = EntityState.Modified;
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(staff);
            }
            catch
            {
                return Content("Data đang được sử dụng bởi một bảng khác");
            }
        }

        
        public ActionResult Delete(STAFF staff, int id)
        {
            try
            {
                // TODO: Add delete logic here
                staff = _db.STAFFs.Where(s => s.ID == id).FirstOrDefault();
                _db.STAFFs.Remove(staff);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Dữ liệu này đang được sử dụng bởi một bảng khác");
            }
        }
    }
}