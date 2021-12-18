using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THDShop.Areas.Manager.Controllers;

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
        public ActionResult LoginAccount(USER _user)
        {
       
            if (!CheckExistAccount(_user))
            {
                ViewBag.ErrorInfo = "Sai info";
                return RedirectToAction("LoginAccount", "LoginCustomer");
            }
            else
            {
                var check = database.USERS.Where(s => s.EMAIL == _user.EMAIL && s.PASSWORD == _user.PASSWORD).FirstOrDefault();
                if (check.ROLENAME == "Customer")
                {
                    database.Configuration.ValidateOnSaveEnabled = false;
                    Session["EMAIL"] = _user.EMAIL;
                    Session["PASSWORD"] = _user.PASSWORD;
                    return RedirectToAction("Index", "HomePage");
                }                
                else
                {
                    var checkM = database.USERS.Where(s => s.EMAIL == _user.EMAIL && s.PASSWORD == _user.PASSWORD).FirstOrDefault();
                    if (checkM.ROLENAME == "Manager"|| checkM.ROLENAME == "Staff")
                    {
                        Session["TENQLY"] = _user.NAME;
                        Session["ID"] = _user.ID;
                        return Redirect("/Manager/Report");
                    }
                }

                return RedirectToAction("Index", "HomePage");
            }

        }
        public ActionResult EditAccount(int ID)
        {
            var detailUser = database.USERS.Where(m => m.ID == ID).FirstOrDefault();
            return View(detailUser);
        }

        [HttpPost]
        public ActionResult EditAccount(USER user)
        {
            var detail = database.USERS.Where(m => m.ID == user.ID);

            if (detail == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                database.Entry(user).State = EntityState.Modified;
                database.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public bool CheckExistAccount(USER _user)
        {

            var check = database.USERS.Where(s => s.EMAIL == _user.EMAIL && s.PASSWORD == _user.PASSWORD).FirstOrDefault();

            if (check != null)
            {
                return true;
            }
            return false;
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
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
                        PHONE=_user.PHONE,
                        NAME=_user.NAME,
                        ADDRESS=_user.ADDRESS,
                        PASSWORD=_user.PASSWORD,
                        ROLENAME = "Customer",
                        IDMYGIFT = _user.ID ,

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

    }
}