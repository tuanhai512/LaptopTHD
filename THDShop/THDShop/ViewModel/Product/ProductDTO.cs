using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THDShop.ViewModel.Product
{
    public class ProductDTO
    {
        public int ID { get; set; }
        public int HOTPRODUCT { get; set; }
        public string NAME { get; set; }
        public int QUANTITY { get; set; }
        public double PRICE { get; set; }
        public double ORI_PRICE { get; set; }
        public string DESCRIPTION { get; set; }
        public string DESCRIPTION_CPU { get; set; }
        public string DESCRIPTION_RAM { get; set; }
        public string DESCRIPTION_STORAGE { get; set; }
        public string DESCRIPTION_CARD { get; set; }
        public string DESCRIPTION_SCREEN { get; set; }
        public string DESCRIPTION_WEIGHT { get; set; }
        public string IMAGE { get; set; }
        public string CATEGORYNAME { get; set; }
        public Nullable<int> IDCATEGORY { get; set; }
    }
}