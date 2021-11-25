using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace THDShop.Areas.Manager.Controllers
{
    public class UserController : Controller
    {
        // GET: Manager/User
        QLLaptopShopEntities _db = new QLLaptopShopEntities();

        public ActionResult Index()
        {
          
            return View(_db.USERS.ToList());
        }


        public ActionResult Details(int id)
        {
            return View(_db.USERS.Where(s => s.ID == id).FirstOrDefault());
        }


        public ActionResult Create()
        {
            USERS user = new USERS();
            return View(user);
        }


        [HttpPost]
        public ActionResult Create(USERS user)
        {
            try
            {
                if (ModelState.IsValid)
                // TODO: Add insert logic here
                {
                    _db.USERS.Add(user);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(user);
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            return View(_db.USERS.Where(s => s.ID == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Edit(USERS user, int id)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    _db.Entry(user).State = EntityState.Modified;
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(user);
            }
            catch
            {
                return Content("Data đang được sử dụng bởi một bảng khác");
            }
        }

        public ActionResult Delete(int id)
        {
            return View(_db.USERS.Where(s => s.ID == id).FirstOrDefault());
        }

        // POST: NhanVien/DonViTinhMon/Delete/5
        [HttpPost]
        public ActionResult Delete(USERS user, int id)
        {
            try
            {
                // TODO: Add delete logic here
                user = _db.USERS.Where(s => s.ID == id).FirstOrDefault();
                _db.USERS.Remove(user);
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