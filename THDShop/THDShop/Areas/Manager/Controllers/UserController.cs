using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THDShop.ViewModel.User;

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
            return View();

        }


        [HttpPost]
        public ActionResult Create(CreateUserInput model)
        {
            try
            {
                if (ModelState.IsValid)
                // TODO: Add insert logic here
                {
                    var entity = new USERS();
                    if (model == null)
                    { entity = new USERS(); }
                    entity.NAME = model.NAME;
                    entity.PASSWORD = model.PASSWORD;
                    entity.ADDRESS = model.ADDRESS;
                    entity.PHONE = model.PHONE;
                    entity.EMAIL = model.EMAIL;
                    entity.AVATAR = model.AVATAR;
                    _db.USERS.Add(entity);
                    _db.SaveChanges();

                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View("Create");
            }
        }


        public ActionResult Edit(int id)
        {
            var entity = _db.USERS.Find(id);
            var model = new UpdateUserInput();
            model.ID = entity.ID;
            model.NAME = entity.NAME;
            model.PASSWORD = entity.PASSWORD;
            model.PHONE = entity.PHONE;
            model.EMAIL = entity.EMAIL;
            model.AVATAR = entity.AVATAR;
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(UpdateUserInput model)
        {

            // TODO: Add update logic here
            if (ModelState.IsValid)
            {
                var entity = new USERS();
                if (model == null)
                    return HttpNotFound();
                entity.ID = model.ID;
                entity.NAME = model.NAME;
                entity.PASSWORD = model.PASSWORD;
                entity.ADDRESS = model.ADDRESS;
                entity.PHONE = model.PHONE;
                entity.EMAIL = model.EMAIL;
                entity.AVATAR = model.AVATAR;
                _db.Entry(entity).State = EntityState.Modified;
                _db.SaveChanges();
             }
            return RedirectToAction("Index");
        }

    

        public ActionResult Delete(int id)
        {

            var entity = _db.USERS.Find(id);
            _db.USERS.Remove(entity);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: NhanVien/DonViTinhMon/Delete/5
        public ActionResult Searchphone(string phone)
        {
            var list = _db.USERS.Where(p => p.PHONE == phone).ToList();

            return View(list);
        }

    }
}