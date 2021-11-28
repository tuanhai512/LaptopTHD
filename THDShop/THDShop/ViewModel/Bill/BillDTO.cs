using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THDShop.ViewModel.Gift
{
    public class BillDTO
    {
        public int ID { get; set; }
        public Nullable<int> IDSTAFF { get; set; }
        public int IDORDER { get; set; }
        public double TOTALMONEY { get; set; }
        public System.DateTime DATETIME { get; set; }
        public string NOTE { get; set; }
        public int METHODS { get; set; }
       
    }
}