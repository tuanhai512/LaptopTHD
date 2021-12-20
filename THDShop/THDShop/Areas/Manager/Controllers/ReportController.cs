using System;
using System.Collections.Generic;
using System.Linq;
using ClosedXML.Excel;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.IO;
using THDShop.ViewModel.Report;

namespace THDShop.Areas.Manager.Controllers
{
    public class ReportController : Controller
    {
        QLLaptopShopEntities database = new QLLaptopShopEntities();

        // GET: Manager/Report
        public ActionResult Index()
        {
            return View(database.REPORT.ToList());
        }

        // GET: Manager/Report/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Manager/Report/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manager/Report/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Manager/Report/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Manager/Report/Edit/5
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

        // GET: Manager/Report/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Manager/Report/Delete/5
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
        [HttpPost]
        public FileResult Export()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[4]{
                new DataColumn("ID"),
                new DataColumn("TOTALMONEY"),
                new DataColumn("DATETIME"),
                new DataColumn("DATETIMEEXPORT")
            });
            var bill = from c in database.BILL.ToList() select c;
            foreach (var b in bill)
            {
                dt.Rows.Add(b.ID, b.TOTALMONEY, b.DATETIME, DateTime.Now);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ReportLaptopShop.xlsx");
                }
            }
           
    }
        public ActionResult Searchday(int day)
        { 
            int month = day;

            var list = database.REPORT.Where(p => p.DATERP.Value.Month == month).ToList();
           
           
            
            return View(list);
        }
    }
}
