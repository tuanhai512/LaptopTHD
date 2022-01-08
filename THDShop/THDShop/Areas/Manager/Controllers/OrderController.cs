using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using THDShop.ViewModel;
//using THDShop.ViewModel.Report;

namespace THDShop.Areas.Manager.Controllers
{
    public class OrderController : Controller 
    {
        //public ReportDTO GetReport()
        //{
        //    ReportDTO getreport = Session["ReportDTO"] as ReportDTO;
        //    if (getreport == null || Session["ReportDTO"] == null)
        //    {
        //        getreport = new ReportDTO();
        //        Session["ReportDTO"] = getreport;
        //    }
        //    return getreport;
        //}
        // GET: Manager/Order
        QLLaptopShopEntities _db = new QLLaptopShopEntities();
        public Phanhoi status;
        // GET: QuanLy/DonHang
        public OrderController()
        {

        }
        public OrderController(Phanhoi _status)
        {
            this.status = _status;
        }
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
                status.Change_Status(id);
            }
            _db.Entry(dathang).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult BillSuccess()
        {
            var model = _db.ORDERS.Where(s => s.STATUS == 2).ToList();
            return View(model);
        }
        public ActionResult Success(int? id)
        {
            //var getreport = GetReport();
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
                        TOTALMONEY = dathang.TOTALMONEY,
                        DATETIME = dathang.DAY,
                        ORI_PRICE = dathang.ORI_PRICE
                        // ID = (int)Session["MAKH"]
                    };
                    _db.BILLs.Add(hoadon);
                    var report = new REPORT()
                    {
                        IDBILL = hoadon.ID,
                        TOTALMONEY =  hoadon.TOTALMONEY,
                        DATERP = hoadon.DATETIME,


                    };
                    _db.REPORTs.Add(report);
                    _db.SaveChanges();

                    //var report = new ReP()
                    //{
                    //    IDBILL = hoadon.ID,
                    //    //IDPRODUCT = product.ID,
                    //    TOTALMONEY = getreport.Income(),
                    //    DATERP = DateTime.Now,
                    //    // ID = (int)Session["MAKH"]
                    //};
                    //_db.REPORTs.Add(report);
                    //_db.SaveChanges();

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
        public ActionResult BillCancel()
        {
            var model = _db.ORDERS.Where(s => s.STATUS == 3).ToList();

            return View(model);
        }
        public ActionResult Cancel(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            ORDER dathang = _db.ORDERS.Find(id);
            DE_ORDER de_order = _db.DE_ORDER.Find(id);
            if (dathang.STATUS == 1)
            {
                dathang.STATUS = 3;
              
            }
            _db.Entry(dathang).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        // GET: QuanLy/DonHang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var order = _db.ORDERS.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
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
        public ActionResult Searchid(int id)
        {
            var list = _db.ORDERS.Where(p => p.ID == id).ToList();
            return View(list);
        }
    }
}