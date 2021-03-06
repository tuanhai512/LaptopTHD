using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace THDShop.Areas.Manager.Controllers
{
    public class RoleController : Controller
    {
        // GET: Manager/Role
        QLLaptopShopEntities database = new QLLaptopShopEntities();
        public ActionResult Index()
        {

            if (Session["IDQL"] != null)
            {
                return View(database.ROLES.ToList());
            }
            return Redirect("/LoginCustomer/LoginAccount");
            
        }

     
        public ActionResult Details(int id)
        {
            return View(database.ROLES.Where(s => s.ID == id).FirstOrDefault());
        }


        public ActionResult Create()
        {
            ROLE role = new ROLE();
            return View(role);
        }

        // POST: QuanLy/KhuyenMai/Create
        [HttpPost]
        public ActionResult Create(ROLE role)
        {
            try
            {
                // TODO: Add insert logic here
                database.ROLES.Add(role);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(database.ROLES.Where(s => s.ID == id).FirstOrDefault());
        }

       
        [HttpPost]
        public ActionResult Edit(ROLE role)
        {
            var detail = database.ROLES.Where(s => s.ID == role.ID);

            if (detail == null)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                database.Entry(role).State = EntityState.Modified;
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: QuanLy/KhachHang/Delete/5
        public ActionResult Delete(int id)
        {
            var entity = database.ROLES.Find(id);
            database.ROLES.Remove(entity);
            database.SaveChanges();
            
            return RedirectToAction("Index");
        }
        public ActionResult Searchname(string name)
        {
            var list = database.ROLES.Where(p => p.NAME == name).ToList();
            return View(list);
        }
      

    }
}