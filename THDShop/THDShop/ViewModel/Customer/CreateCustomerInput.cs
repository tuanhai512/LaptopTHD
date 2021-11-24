using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace THDShop.ViewModel.Customer
{
    public class CreateCustomerInput
    {
        [Required]
        [Display(Name = "Tên loại")]
        public int IDUSER { get; set; }
        public string PASSWORD { get; set; }
    }
    public class UpdateCustomerInput : CreateCustomerInput
    {
        public int ID { get; set; }
    }
}