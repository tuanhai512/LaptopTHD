using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THDShop.Areas.Manager.Controllers;
using THDShop.ViewModel.User;

namespace THDShop.Controllers
{
    public class LoginCustomerController : Controller
    {
        // GET: LoginCustomer
        QLLaptopShopEntities database = new QLLaptopShopEntities();
        // GET: LoginUser
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoginAccount()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginAccount(CUSTOMER _user)
        {
       
            if (!CheckExistAccount(_user))
            {
                ViewBag.ErrorInfo = "Sai info";
                return RedirectToAction("LoginAccount", "LoginCustomer");
            }
            else
            {
                var check = database.CUSTOMERs.Where(s => s.EMAIL == _user.EMAIL && s.PASSWORD == _user.PASSWORD).FirstOrDefault();
                if (check.ROLENAME == "Customer")
                {
                    database.Configuration.ValidateOnSaveEnabled = false;
                    Session["ID"] = check.ID;

                    int a = (int)Session["ID"];
                    Session["EMAIL"] = _user.EMAIL;
                    Session["PASSWORD"] = _user.PASSWORD;
                    
                    return RedirectToAction("Index", "HomePage");
                }                
                else
                {
                    var checkM = database.CUSTOMERs.Where(s => s.EMAIL == _user.EMAIL && s.PASSWORD == _user.PASSWORD).FirstOrDefault();
                    if (checkM.ROLE.NAME == "Manager")
                    {
                        Session["IDQL"] = check.ID;
                        Session["EMAIL"] = _user.EMAIL;
                        Session["PASSWORD"] = _user.PASSWORD;
                        return Redirect("/Manager/Report");
                    }
                    if (checkM.ROLE.NAME == "Staff")
                    {
                        Session["IDNV"] = check.ID;
                        Session["EMAIL"] = _user.EMAIL;
                        Session["PASSWORD"] = _user.PASSWORD;
                        return Redirect("/Manager/Order");
                    }    
                }

                return RedirectToAction("Index", "HomePage");
            }

        }
        public ActionResult Details(int ID)
        {
            var detailUser = database.CUSTOMERs.Where(m => m.ID == ID).FirstOrDefault();
            return View(detailUser);
        }
        public ActionResult EditAccount(int ID)
        {
            var entity = database.CUSTOMERs.Find(ID);
            var model = new UpdateUserInput();

            model.ID = entity.ID;
            model.IDCUS = entity.IDUSER;
            model.NAME = entity.NAME;
            model.ADDRESS = entity.ADDRESS;
            model.PHONE = entity.PHONE;
            model.EMAIL = entity.EMAIL;
            model.AVATAR = entity.AVATAR;
            model.ROLENAME = entity.ROLENAME;

            return View(model);
        }

        [HttpPost]
        public ActionResult EditAccount(UpdateUserInput model)
        {

            var entity = new CUSTOMER();
            var entity2 = new USER();
            if (model == null)
                return HttpNotFound();

            
            if (model.UploadImage != null)
            {
                string filename = Path.GetFileNameWithoutExtension(model.UploadImage.FileName);
                string extent = Path.GetExtension(model.UploadImage.FileName);
                filename = filename + extent;
                model.AVATAR = "~/Assets/Images/" + filename;
                model.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Assets/Images"), filename));

            }
            entity.ID = model.ID;
            entity.IDUSER = model.IDCUS;
            entity.NAME = model.NAME;
            entity.ADDRESS = model.ADDRESS;
            entity.PHONE = model.PHONE;
            entity.PASSWORD = model.PASSWORD;
            entity.EMAIL = model.EMAIL;
            entity.AVATAR = model.AVATAR;
            entity.ROLENAME = model.ROLENAME;
            database.Entry(entity).State = EntityState.Modified;
            database.SaveChanges();

            entity2.ID = model.IDCUS;
            entity2.NAME = model.NAME;
            entity2.ADDRESS = model.ADDRESS;
            entity2.PHONE = model.PHONE;
            entity2.PASSWORD = model.PASSWORD;
            entity2.EMAIL = model.EMAIL;
            entity2.AVATAR = model.AVATAR;
            entity2.ROLENAME = model.ROLENAME;
            database.Entry(entity2).State = EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("Logout");
        }

        public bool CheckExistAccount(CUSTOMER _user)
        {

            var check = database.CUSTOMERs.Where(s => s.EMAIL == _user.EMAIL && s.PASSWORD == _user.PASSWORD).FirstOrDefault();

            if (check != null)
            {
                return true;
            }
            return false;
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "HomePage");
        }
        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(USER _user)
        {

                if (ModelState.IsValid)
                {

                    var check_ID = database.USERS.Where(s => s.EMAIL == _user.EMAIL).FirstOrDefault();
                    if (check_ID == null)
                    {
                        database.Configuration.ValidateOnSaveEnabled = false;

                        _user.ROLENAME = "Customer";

                        database.USERS.Add(_user);
                        var _cus = new CUSTOMER()
                        {
                            EMAIL = _user.EMAIL,
                            PHONE = _user.PHONE,
                            NAME = _user.NAME,
                            ADDRESS = _user.ADDRESS,
                            PASSWORD = _user.PASSWORD,
                            ROLENAME = _user.ROLENAME,
                        };
                        database.CUSTOMERs.Add(_cus);
                        database.SaveChanges();
                        return RedirectToAction("LoginAccount");
                    }
                    else
                    {
                        ViewBag.ErrorRegister = "This ID is exist";
                        return View();
                    }
                }
            return View();
        }
        public ActionResult MyGift(int id)
        {
            var bill = database.MYGIFTs.Where(m => m.IDCUS == id).ToList();
            return View(bill);
        }

        public ActionResult DonDat(int id)
        {
            var bill = database.ORDERS.Where(m => m.DELI_ADDRESS.CUSTOMER.ID == id).ToList();
            return View(bill);
        }
    }
}