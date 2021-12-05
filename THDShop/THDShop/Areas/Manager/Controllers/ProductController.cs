using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THDShop;
using THDShop.ViewModel.Product;

namespace THDShop.Areas.Manager.Controllers
{
    public class ProductController : Controller
    {
        // GET: Manager/Product
        private QLLaptopShopEntities _context = new QLLaptopShopEntities();
        public ProductController()
        {
            ProductSingleton.Instance.Init(_context);
        }
        public ActionResult Index(int id = 0)
        {
            //var query = from c in _context.PRODUCTS
            //            select new ProductDTO
            //            {
            //                ID = c.ID,
            //                NAME = c.NAME,
            //                PRICE = c.PRICE,
            //                ORI_PRICE = c.ORI_PRICE,
            //                DESCRIPTION = c.DESCRIPTION,
            //                CATEGORYNAME = c.CATEGORy.NAME,
            //                IDCATEGORY = c.IDCATEGORY,
            //                QUANTITY = c.QUANTITY,
            //                IMAGE = c.IMAGE,
            //                DESCRIPTION_CPU = c.DESCRIPTION_CPU,
            //                DESCRIPTION_RAM = c.DESCRIPTION_RAM,
            //                DESCRIPTION_STORAGE = c.DESCRIPTION_STORAGE,
            //                DESCRIPTION_CARD = c.DESCRIPTION_CARD,
            //                DESCRIPTION_SCREEN = c.DESCRIPTION_SCREEN,
            //                DESCRIPTION_WEIGHT = c.DESCRIPTION_WEIGHT,
            //            };
            //return View(query.ToList());
            //var query = ProductSingleton.Instance.listProduct;
            //return View(query.ToList());
            var links = from l in _context.PRODUCTS
                        select l;
            if (id != 0)
            {
                links = links.Where(x => x.ID == id);
                return View(links);
            }
            return View(links);
        }
        public ActionResult Create()
        {
            var categorylist = _context.CATEGORIES.ToList().Select(
            x => new SelectListItem
            {
                Text = x.NAME,
                Value = Convert.ToString(x.ID)
            }
           );
            ViewBag.Categories = categorylist;
            CreateProductInput prod = new CreateProductInput();
            return View(prod);

        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(CreateProductInput model)
        {
            var entity = new PRODUCT();
            if (model != null)
            {
                entity = new PRODUCT();
                var categorylist = _context.CATEGORIES.ToList().Select(
                x => new SelectListItem
                {
                    Text = x.NAME,
                    Value = Convert.ToString(x.ID)
                }
                );
                ViewBag.Categories = categorylist;
                if (model.UploadImage != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(model.UploadImage.FileName);
                    string extent = Path.GetExtension(model.UploadImage.FileName);
                    filename = filename + extent;
                    model.IMAGE = "~/Assets/Images/" + filename;
                    model.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Assets/Images"), filename));
                }
                entity.IMAGE = model.IMAGE;
                if (ModelState.IsValid)
                {
                    entity.ID = model.ID;
                    entity.NAME = model.NAME;
                    entity.PRICE = model.PRICE.HasValue ? model.PRICE.Value : 0;
                    entity.ORI_PRICE = model.ORI_PRICE.HasValue ? model.ORI_PRICE.Value : 0;
                    entity.USD_PRICE = model.USD_PRICE().HasValue ? model.USD_PRICE().Value :0;
                    entity.QUANTITY = model.QUANTITY.HasValue ? model.QUANTITY.Value : 0;
                    entity.DESCRIPTION = model.DESCRIPTION;
                    entity.DESCRIPTION_CPU = model.DESCRIPTION_CPU;
                    entity.DESCRIPTION_RAM = model.DESCRIPTION_RAM;
                    entity.DESCRIPTION_STORAGE = model.DESCRIPTION_STORAGE;
                    entity.DESCRIPTION_CARD = model.DESCRIPTION_CARD;
                    entity.DESCRIPTION_SCREEN = model.DESCRIPTION_SCREEN;
                    entity.DESCRIPTION_WEIGHT = model.DESCRIPTION_WEIGHT;
                    entity.IDCATEGORY = model.IDCATEGORY;
                    _context.PRODUCTS.Add(entity);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {

                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult Edit(int ID)
        {
            var entity = _context.PRODUCTS.Find(ID);
            var model = new UpdateProductInput();
            var categorylist = _context.CATEGORIES.ToList().Select(
                x => new SelectListItem
                {
                    Text = x.NAME,
                    Value = Convert.ToString(x.ID)
                }
                );
            ViewBag.Categories = categorylist;
            model.ID = entity.ID;
           // model.HOTPRODUCT = entity.HOTPRODUCT;
            model.NAME = entity.NAME;
            model.PRICE = entity.PRICE;
            model.ORI_PRICE = entity.ORI_PRICE;
            model.QUANTITY = entity.QUANTITY;
            model.DESCRIPTION = entity.DESCRIPTION;
            model.DESCRIPTION_CPU = entity.DESCRIPTION_CPU;
            model.DESCRIPTION_RAM = entity.DESCRIPTION_RAM;
            model.DESCRIPTION_STORAGE = entity.DESCRIPTION_STORAGE;
            model.DESCRIPTION_CARD = entity.DESCRIPTION_CARD;
            model.DESCRIPTION_SCREEN = entity.DESCRIPTION_SCREEN;
            model.DESCRIPTION_WEIGHT = entity.DESCRIPTION_WEIGHT;
            model.IDCATEGORY = entity.IDCATEGORY;
            model.IMAGE = entity.IMAGE;
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(UpdateProductInput model)
        {
            var entity = new PRODUCT();
            if (model == null)
                return HttpNotFound();

            var categorylist = _context.CATEGORIES.ToList().Select(
                x => new SelectListItem
                {
                    Text = x.NAME,
                    Value = Convert.ToString(x.ID)
                }
                );
            ViewBag.Categories = categorylist;

            if (model.UploadImage != null)
            {
                string filename = Path.GetFileNameWithoutExtension(model.UploadImage.FileName);
                string extent = Path.GetExtension(model.UploadImage.FileName);
                filename = filename + extent;
                model.IMAGE = "~/Assets/Images/" + filename;
                model.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Assets/Images"), filename));

            }
            entity.ID = model.ID;
          //  entity.HOTPRODUCT = model.HOTPRODUCT;
            entity.NAME = model.NAME;
            entity.PRICE = model.PRICE.HasValue ? model.PRICE.Value : 0;
            entity.ORI_PRICE = model.ORI_PRICE.HasValue ? model.ORI_PRICE.Value : 0;
            entity.USD_PRICE = model.USD_PRICE().HasValue ? model.USD_PRICE().Value : 0;
            entity.QUANTITY = model.QUANTITY.HasValue ? model.QUANTITY.Value : 0;
            entity.DESCRIPTION = model.DESCRIPTION;
            entity.DESCRIPTION_CPU = model.DESCRIPTION_CPU;
            entity.DESCRIPTION_RAM = model.DESCRIPTION_RAM;
            entity.DESCRIPTION_STORAGE = model.DESCRIPTION_STORAGE;
            entity.DESCRIPTION_CARD = model.DESCRIPTION_CARD;
            entity.DESCRIPTION_SCREEN = model.DESCRIPTION_SCREEN;
            entity.DESCRIPTION_WEIGHT = model.DESCRIPTION_WEIGHT;
            entity.IDCATEGORY = model.IDCATEGORY;
            entity.IMAGE = model.IMAGE;

            this._context.Entry(entity).State = EntityState.Modified;
            this._context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id, PRODUCT prod)
        {
            try
            {
                prod = _context.PRODUCTS.Where(s => s.ID == id).FirstOrDefault();
                _context.PRODUCTS.Remove(prod);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Dữ liệu này đang được sử dụng bởi một bảng khác");
            }
        }

        public ActionResult Detail(DetailProductDTO model, int ID)
        {
            var query = from c in _context.PRODUCTS
                        where c.ID == ID
                        select new DetailProductDTO
                        {
                            ID = c.ID,
                           // HOTPRODUCT = c.HOTPRODUCTS,
                            NAME = c.NAME,
                            PRICE = c.PRICE,
                            ORI_PRICE = c.ORI_PRICE,
                            QUANTITY = c.QUANTITY,
                            DESCRIPTION = c.DESCRIPTION,
                            IMAGE = c.IMAGE,
                            CATEGORYNAME = c.CATEGORy.NAME,
                            DESCRIPTION_CPU = c.DESCRIPTION_CPU,
                            DESCRIPTION_RAM = c.DESCRIPTION_RAM,
                            DESCRIPTION_STORAGE = c.DESCRIPTION_STORAGE,
                            DESCRIPTION_CARD = c.DESCRIPTION_CARD,
                            DESCRIPTION_SCREEN = c.DESCRIPTION_SCREEN,
                            DESCRIPTION_WEIGHT = c.DESCRIPTION_WEIGHT
                        };

            return View(query.First());
        }
    }
}