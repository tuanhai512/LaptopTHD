using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace THDShop.ViewModel.Report
{
    public class ReportItems
    {
        public PRODUCT _product { get; set; }
        public BILL _bill { get; set; }
        public DE_BILL _de_bill { get; set; }

        public double _totalmoney { get; set; }
    }
    public class ReportDTO
    {
        public double TOTALMONEY { get; set; }

        public DateTime DATERP { get; set; }
        public int ID { get; set; }
        public int IDBILL { get; set; }
        public int IDPRODUCT { get; set; }

        public virtual PRODUCT PRODUCT { get; set; }


        List<ReportItems> items = new List<ReportItems>();
        public IEnumerable<ReportItems> Items
        {
            get { return items; }
        }
        public int Income()
        {
            var total = items.Sum(s => s._product.PRICE - s._product.ORI_PRICE);
            return (int)total;
        }
    }
   
}