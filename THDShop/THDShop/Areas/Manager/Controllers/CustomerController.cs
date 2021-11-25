using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THDShop.ViewModel.Customer;

namespace THDShop.Areas.Manager.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Manager/Customer
        private QLLaptopShopEntities _context = new QLLaptopShopEntities();

        public CustomerController()
        {
            CustomerSingleton.Instance.Init(_context);

        }

        //public CustomerController(QLLaptopShopEntities context)
        //{
        //    this._context = context;
        //    CustomerSingleton.Instance.Init(context);

        //}
        public ActionResult Index()
        {
            //if (Session["IDQL"] == null)
            //{
            //    return RedirectToAction("Index", "LoginQuanLy");
            //}
            var query = CustomerSingleton.Instance.listCustomer;
            return View(query.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CreateCustomerInput model)
        {
            var entity = new CUSTOMER();
            if (model == null)
                entity = new CUSTOMER();
            entity.ID = model.IDUSER;
            entity.NAME = model.NAME;
            entity.PASSWORD = model.PASSWORD;
            entity.ADDRESS = model.ADDRESS;
            entity.PHONE = model.PHONE;
            entity.EMAIL = model.EMAIL;
            entity.AVATAR = model.AVATAR;
            entity.POINT_MY = 0;
            _context.CUSTOMERs.Add(entity);
            _context.SaveChanges();
            CustomerSingleton.Instance.listCustomer.Clear();
            CustomerSingleton.Instance.Init(_context);
            var customer = CustomerSingleton.Instance.listCustomer;
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var entity = this._context.CUSTOMER.Find(id);
            var model = new UpdateCustomerInput();
            model.IDUSER = entity.IDUSER;
            model.PASSWORD = entity.PASSWORD;
            model.ADDRESS = entity.ADDRESS;
            model.PHONE = entity.PHONE;
            model.EMAIL = entity.EMAIL;
            model.AVATAR = entity.AVATAR;
            model.POINT_MY = entity.POINT_MY;
            return View(model);
        }
        [HttpPut]
        public ActionResult Edit(UpdateCustomerInput model)
        {
            var entity = new CUSTOMER();
            if (model == null)
                return HttpNotFound();
            entity.ID = model.IDUSER;
            entity.NAME = model.NAME;
            entity.PASSWORD = model.PASSWORD;
            entity.ADDRESS = model.ADDRESS;
            entity.PHONE = model.PHONE;
            entity.EMAIL = model.EMAIL;
            entity.AVATAR = model.AVATAR;
            entity.POINT_MY = model.POINT_MY;
            this._context.Entry(entity).State = EntityState.Modified;
            this._context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var entity = this._context.CUSTOMER.Find(id);
            this._context.CUSTOMER.Remove(entity);
            this._context.SaveChanges();
            CustomerSingleton.Instance.listCustomer.Clear();
            CustomerSingleton.Instance.Init(_context);
            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id)
        {
            var query = from c in _context.CUSTOMER
                        where c.IDUSER == id
                        select new DetailCustomerDTO
                        {
                            IDUSER = c.IDUSER,
                            NAME = c.NAME
                        };

            return View(query.First());
        }
    }
}