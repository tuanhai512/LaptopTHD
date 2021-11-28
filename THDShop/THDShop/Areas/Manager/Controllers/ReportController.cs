using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THDShop.ViewModel;
using THDShop.ViewModel.Report;

namespace THDShop.Areas.Manager.Controllers
{
    public class ReportController : Controller
    {
        // GET: Manager/Report
        QLLaptopShopEntities _db = new QLLaptopShopEntities();

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Index(ReportDTO report)
        {
            
            //List<PRODUCT> pro = _db.PRODUCTS.Where(s => s.ID == report.IDPRODUCT).ToList();
            //List<BILL> BILL = _db.BILLs.Where(s => s.ID == report.IDBILL).ToList();
            return View();
        }
        [HttpPost]
        public FileResult Export()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange( new DataColumn[4]{ 
                new DataColumn("ID"),
                new DataColumn("TOTALMONEY"),
                new DataColumn("DATETIME"),
                new DataColumn("DATETIMEEXPORT")
            }) ;
            var bill = from c in _db.BILLs.ToList() select c;
            foreach( var b in bill )
            {
                dt.Rows.Add(b.ID, b.TOTALMONEY, b.DATETIME, DateTime.Now);
            }    
            using(XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using(MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ReportLaptopShop.xlsx");
                }    
            }    
        }
       
    }
}