
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace THDShop.ViewModel.Gift
{
    public class CreateGiftInput
    {
        public string ID { get; set; }
        public int G_POINT { get; set; }
        public int G_VALUE { get; set; }
        public Nullable<DateTime> G_START { get; set; }
        public Nullable<DateTime> G_END { get; set; }
        public string DESCREPTION { get; set; }
        public int QUANTITY { get; set; }

    }
    public class UpdateGiftInput : CreateGiftInput
    {

    }
}