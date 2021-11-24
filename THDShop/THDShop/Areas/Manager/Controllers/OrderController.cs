using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THDShop.ViewModel;

namespace THDShop.Areas.Manager.Controllers
{
    public class OrderController : Controller
    {
        // GET: Manager/Order
        QLLaptopShopEntities _db = new QLLaptopShopEntities();
        // GET: QuanLy/DonHang
        public ActionResult ShowMonAn()
        {
            if (Session["GioHang"] == null)
                return RedirectToAction("ShowMonAn", "DonHang");
            Cart _gioHang = Session["GioHang"] as Cart;
            return View(_gioHang);
        }
        public ActionResult Index()
        {
            return View(_db.ORDERS.ToList());
        }
        public ActionResult Comfirm(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            ORDER dathang = _db.ORDERS.Find(id);
            if (dathang.STATUS == 0)
            {
                dathang.STATUS = 1;
            }
            _db.Entry(dathang).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Success(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            //int temp = (int)Session["MAKH"];
            ORDER dathang = _db.ORDERS.Find(id);
            if (dathang.STATUS == 1)
            {
                if (ModelState.IsValid)
                {

                    var hoadon = new BILL()
                    {
                        IDORDER = dathang.ID,
                        TOTALMONEY = (double)dathang.TOTALMONEY,
                        DATETIME = dathang.DAY,
                       // ID = (int)Session["MAKH"]

                    };
                    _db.BILLs.Add(hoadon);
                    _db.SaveChanges();

                    var mONAN_DATHANG = _db.DE_ORDER.Where(m => m.IDORDER == id).ToList();
                    foreach (var item in mONAN_DATHANG)
                    {
                        var cthoadon = new DE_BILL()
                        {
                            IDBILL = hoadon.ID,
                            IDORDER = item.IDORDER,
                            IDPRODUCT = item.IDPRODUCT,
                            QUANTITY = item.QUANTITY,
                        };
                        _db.DE_BILL.Add(cthoadon);
                        _db.SaveChanges();
                    }

                    dathang.STATUS = 2;
                    _db.Entry(dathang).State = EntityState.Modified;
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index");

        }
        public ActionResult Cancel(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            ORDER dathang = _db.ORDERS.Find(id);
            if (dathang.STATUS == 1)
            {
                dathang.STATUS = 3;
            }
            _db.Entry(dathang).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        // GET: QuanLy/DonHang/Details/5
        public ActionResult Details()
        {
            return View();
        }

        // POST: QuanLy/DonHang/Delete/5
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