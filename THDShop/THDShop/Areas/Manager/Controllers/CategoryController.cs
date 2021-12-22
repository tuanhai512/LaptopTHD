using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THDShop.ViewModel.Category;

namespace THDShop.Areas.Manager.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Manager/Category

        private QLLaptopShopEntities _context = new QLLaptopShopEntities();    
        
        public CategoryController()
        {
            CategorySingleton.Instance.Init(_context);
        }
        public ActionResult Index()
        {
            //if (Session["IDQL"] == null)
            //{
            //    return RedirectToAction("Index", "LoginQuanLy");
            //}
            var query = CategorySingleton.Instance.listCategory;
            return View(query.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CreateCategoryInput model)
        {
            var entity = new CATEGORy();
            if (model == null)
                entity = new CATEGORy();

            entity.NAME = model.NAME;
            entity.CREATEAT = DateTime.Now;

            _context.CATEGORIES.Add(entity);
            _context.SaveChanges();
            CategorySingleton.Instance.listCategory.Clear();
            CategorySingleton.Instance.Init(_context);
            // var category = CategorySingleton.Instance.listCategory;
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var entity = _context.CATEGORIES.Find(id);
            var model = new UpdateCategoryInput();
            model.ID = entity.ID;
            model.NAME = entity.NAME;
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(UpdateCategoryInput model)
        {
            var entity = new CATEGORy();
            if (model == null)
                return HttpNotFound();
            entity.ID = model.ID;
            entity.NAME = model.NAME;
            entity.CREATEAT = DateTime.Now;
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            CategorySingleton.Instance.listCategory.Clear();
            CategorySingleton.Instance.Init(_context);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var entity = _context.CATEGORIES.Find(id);
            _context.CATEGORIES.Remove(entity);
            _context.SaveChanges();
            CategorySingleton.Instance.listCategory.Clear();
            CategorySingleton.Instance.Init(_context);
            return RedirectToAction("Index");
        }
        public ActionResult Duplicate(int id)
        {
            var post = _context.CATEGORIES.Find(id);
            //var cloneCate = post.Clone();       
            //_context.CATEGORIES.Add((CATEGORy)cloneCate);
            _context.SaveChanges();
            CategorySingleton.Instance.listCategory.Clear();
            CategorySingleton.Instance.Init(_context);
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
            var query = from c in _context.CATEGORIES
                        where c.ID == id
                        select new DetailCustomerDTO
                        {
                            ID = c.ID,
                            NAME = c.NAME
                        };

            return View(query.First());
        }
        public PartialViewResult LoaiPartial()
        {
            var loaiList = _context.CATEGORIES.ToList();
            return PartialView(loaiList);
        }
    }
}