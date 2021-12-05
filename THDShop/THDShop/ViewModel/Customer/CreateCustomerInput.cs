using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace THDShop.ViewModel.Customer
{
    public class CreateCustomerInput
    {
        public int ID { get; set; }
        public int IDUSER { get; set; }
        public string NAME { get; set; }
        public Nullable<System.DateTime> BIRTHDAY { get; set; }
        public string ADDRESS { get; set; }
        public string PHONE { get; set; }
        public string EMAIL { get; set; }
        public string PASSWORD { get; set; }
        public string AVATAR { get; set; }
        public int POINT_MY { get; set; }
        public int IDMYGIFT { get; set; }

    }
    public class UpdateCustomerInput : CreateCustomerInput
    {
       
    }
}