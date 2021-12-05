using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;


namespace THDShop.ViewModel.DeliAddress
{
    public class CheckOutDetails
    {
        public string NAME { get; set; }
        public int QUANTITY { get; set; }
        public int PRICE { get; set; }
        public string ADDRESS { get; set; }
        public string WARD { get; set; }
        public string DISTRICT { get; set; }
        public string NOTE { get; set; }
        public string PHONE { get; set; }
    }
}