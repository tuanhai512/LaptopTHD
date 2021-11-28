using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using THDShop.ViewModel.Gift;
using System.Web.Mvc;

namespace THDShop.Areas.Manager.Controllers
{
    public class GiftController : Controller
    {
        QLLaptopShopEntities _db = new QLLaptopShopEntities();
        // GET: Manager/Gift
        public ActionResult Index()
        {
            return View(_db.GIFTs.ToList());
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

        // POST: QuanLy/KhuyenMai/Create
        [HttpPost]
        public ActionResult Create(CreateGiftInput model)
        {

            // TODO: Add insert logic here
            //_db.GIFTs.Add(gift);
            //_db.SaveChanges();
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = new GIFT();
                    if (model == null)
                    { entity = new GIFT(); }
                    entity.ID = model.ID;
                    entity.G_POINT = model.G_POINT;
                    entity.G_VALUE = model.G_VALUE;
                    entity.G_START = model.G_START;
                    entity.G_END = model.G_END;
                    entity.DESCREPTION = model.DESCREPTION;
                    entity.QUANTITY = model.QUANTITY;
                    _db.GIFTs.Add(entity);
                    _db.SaveChanges();
                  
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Create");
            }


        }

        // GET: Manager/Gift/Edit/5
        public ActionResult Edit(string id)
        {
            var entity = _db.GIFTs.Find(id);
            var model = new UpdateGiftInput();
            model.ID = entity.ID;
            model.G_POINT = entity.G_POINT;

            model.G_VALUE = entity.G_VALUE;
            model.G_START = entity.G_START;
            model.G_END = entity.G_END;
            model.DESCREPTION = entity.DESCREPTION;
            model.QUANTITY = entity.QUANTITY;
            return View(model);
        }


        [HttpPost]
        public ActionResult Edit(UpdateGiftInput model)
        {
            var entity = new GIFT();
            if (model == null)
            { entity = new GIFT(); }
            entity.ID = model.ID;
            entity.G_POINT = model.G_POINT;
            entity.G_VALUE = model.G_VALUE;
            entity.G_START = (DateTime)model.G_START;
            entity.G_END = (DateTime)model.G_END;
            entity.DESCREPTION = model.DESCREPTION;
            entity.QUANTITY = model.QUANTITY;
            _db.GIFTs.Add(entity);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: QuanLy/KhachHang/Delete/5
        public ActionResult Delete(string id)
        {
            var entity = _db.GIFTs.Find(id);
            _db.GIFTs.Remove(entity);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
