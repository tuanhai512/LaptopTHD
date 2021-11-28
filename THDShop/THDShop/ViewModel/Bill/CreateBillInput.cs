
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace THDShop.ViewModel.Gift
{
    public class CreateBillInput
    {
        public string ID { get; set; }
        public int G_POINT { get; set; }
        public double G_VALUE { get; set; }
        public System.DateTime G_START { get; set; }
        public System.DateTime G_END { get; set; }
        public string DESCREPTION { get; set; }
        public int QUANTITY { get; set; }

    }
    public class UpdateBillInput : CreateGiftInput
    {

    }
}