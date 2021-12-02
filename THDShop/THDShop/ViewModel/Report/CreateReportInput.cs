
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace THDShop.ViewModel.Report
{
    public class CreateReportInput
    {

        public string ID { get; set; }
        public int IDBILL { get; set; }
        public double INCOME { get; set; }

        public System.DateTime DATE { get; set; }

    }
    public class UpdateReportInput : CreateReportInput
    {

    }
}