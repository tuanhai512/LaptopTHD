using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THDShop.ViewModel.Report
{
    public class ReportDTO
    {
        public int ID { get; set; }
        public int IDBILL { get; set; }
        public float TOTALMONEY { get; set; }
        public System.DateTime DATERP { get; set; }
        public double Tongdoanhthu()
        {
            var tdt = TOTALMONEY - BILL.ORI_PRICE;
            return tdt;
        }

        public virtual BILL BILL { get; set; }
    }
}