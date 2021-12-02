using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace THDShop.ViewModel.Category
{
    public class CategoryDTO
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public Nullable<int> CREATEBY { get; set; }
        public System.DateTime CREATEAT { get; set; }
        public Nullable<int> UPDATEBY { get; set; }
        public Nullable<System.DateTime> UPDATEAT { get; set; }
        [NotMapped]
        public List<CategoryDTO> listLoai { get; internal set; }
    }
}