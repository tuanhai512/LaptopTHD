using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THDShop.ViewModel.Report
{
    public class ReportDTO
    {
        public string ID { get; set; }
        public int IDBILL { get; set; }
        public double INCOME { get; set; }

        public System.DateTime DATE { get; set; }
        
    }
}