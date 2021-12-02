using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THDShop.ViewModel.Gift;

namespace THDShop.Areas.Manager.Controllers
{
    public class GiftController : Controller
    {
        // GET: Manager/Gift
        QLLaptopShopEntities _db = new QLLaptopShopEntities();
        public ActionResult Index()
        {
            var query = from c in _db.GIFT
                        select new GiftDTO
                        {
                            DESCREPTION = c.DESCREPTION,
                            G_POINT = c.G_POINT,
                            G_START = c.G_START,
                            G_END = c.G_END,
                            ID = c.ID,
                            QUANTITY = c.QUANTITY,
                            G_VALUE = c.G_VALUE
                        };
            return View(query.ToList());
        }

        // GET: Manager/Gift/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Manager/Gift/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manager/Gift/Create
        [HttpPost]
        public ActionResult Create(CreateGiftInput model)
        {
            try
            {
                // TODO: Add insert logic here
                var entity = new GIFT();
                if (model == null)
                  entity = new GIFT();

                entity.ID = model.ID;
                entity.G_POINT = model.G_POINT;
                entity.G_VALUE = model.G_VALUE;
                entity.G_START = model.G_START;
                entity.G_END = model.G_END;
                entity.DESCREPTION = model.DESCREPTION;
                entity.QUANTITY = model.QUANTITY;
                _db.GIFT.Add(entity);
                _db.SaveChanges();        
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Manager/Gift/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Manager/Gift/Edit/5
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

        // GET: Manager/Gift/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Manager/Gift/Delete/5
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
