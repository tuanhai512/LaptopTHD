using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace THDShop.ViewModel.Category
{
  
    public class CreateCategoryInput
    {
        [Required]
        [Display(Name = "Tên loại")]
        public string NAME { get; set; }

    }
    public class UpdateCategoryInput : CreateCategoryInput
    {
        public int ID { get; set; }
    }
}