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

            if (Session["IDQL"] != null)
            {
                return View(_db.USERS.ToList());
            }
            return Redirect("/LoginCustomer/LoginAccount");
            
        }
        public ActionResult Staff()
        {


            return View(_db.USERS.Where(s=>s.IDROLE==2).ToList());
        }
        public ActionResult Customer()
        {


            return View(_db.USERS.Where(s => s.IDROLE == 1).ToList());
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
            var roleList = _db.ROLES.ToList().Select(
                     x => new SelectListItem
                     {
                         Text = x.NAME,
                         Value = Convert.ToString(x.ID)
                     }
                     );
            ViewBag.Roles = roleList;
            try
            {
                if (ModelState.IsValid)
                // TODO: Add insert logic here
                {
                    //model.ROLENAME = "Staff";

                    var entity = new USER();

                    if (model == null)
                    { entity = new USER(); }
                    entity.NAME = model.NAME;
                    entity.PASSWORD = model.PASSWORD;
                    entity.ADDRESS = model.ADDRESS;
                    entity.PHONE = model.PHONE;
                    entity.EMAIL = model.EMAIL;
                    entity.AVATAR = model.AVATAR;
                    entity.IDROLE = model.IDROLE;
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
            var roleList = _db.ROLES.ToList().Select(
                         x => new SelectListItem
                         {
                             Text = x.NAME,
                             Value = Convert.ToString(x.ID)
                         }
                         );
            ViewBag.Roles = roleList;
          
            var model = new UpdateUserInput();
            model.ID = entity.ID;
            model.NAME = entity.NAME;
            model.PASSWORD = entity.PASSWORD;
            model.PHONE = entity.PHONE;
            model.EMAIL = entity.EMAIL;
            model.AVATAR = entity.AVATAR;
            entity.IDROLE = model.IDROLE;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(UpdateUserInput model)
        {
            //List<ROLE> list = _db.ROLES.ToList();

            var roleList = _db.ROLES.ToList().Select(
                       x => new SelectListItem
                       {
                           Text = x.NAME,
                           Value=Convert.ToString(x.ID)
                       }
                       );
            ViewBag.Roles = roleList;

            // TODO: Add update logic here
          
                var entity = new USER();
                if (model == null)
                    return HttpNotFound();
                entity.ID = model.ID;
                entity.NAME = model.NAME;
                entity.PASSWORD = model.PASSWORD;
                entity.ADDRESS = model.ADDRESS;
                entity.PHONE = model.PHONE;
                entity.EMAIL = model.EMAIL;
                entity.IDROLE = model.IDROLE;
                entity.AVATAR = model.AVATAR;
                

                _db.Entry(entity).State = EntityState.Modified;
                _db.SaveChanges();
             
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
        //public ActionResult SelectRole()
        //{
        //    ROLE se_loai = new ROLE();
        //    se_loai.listRole = _db.ROLES.ToList<ROLE>();
        //    return PartialView(se_loai);
        //}
    }
}