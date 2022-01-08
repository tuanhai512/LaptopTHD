
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using static THDShop.ViewModel.Proxy;

namespace THDShop.ViewModel.Product
{
    public class CreateProductInput : IMath 
    {
        private Proxy.Math math = new Proxy.Math();
        public int USD_PRICE(int? x)
        {
            var usdprice = (ORI_PRICE*2) / 22000;
            x = usdprice;
            return math.USD_PRICE(x);
        }
        
        //Constructor: assigns strategy to interface  

        public CreateProductInput( )
        {
            IMAGE = "~/Assets/Images/upload.png";
        }
        public int ID { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập tên ")]
        [Display(Name = "Tên sản phẩm")]
        public string NAME { get; set; }

        [Required(ErrorMessage = "Bạn chưa chọn loại sản phẩm")]
        [Display(Name = "Loại sản phẩm")]
        public int? IDCATEGORY { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Số lượng không được âm")]
        [Required(ErrorMessage = "Bạn chưa nhập số lượng")]
        [Display(Name = "Số lượng")]
        public int? QUANTITY { get; set; }

        //[Range(1, int.MaxValue, ErrorMessage = "Giá không được âm")]
        //[Required(ErrorMessage = "Bạn chưa nhập giá bán")]
        //[Display(Name = "Giá Bán")]
        public int? PRICE { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Giá không được âm")]
        [Required(ErrorMessage = "Bạn chưa nhập giá gốc")]
        [Display(Name = "Giá Gốc")]
        public int? ORI_PRICE { get; set; }


        [Required(ErrorMessage = "Bạn chưa nhập mô tả")]
        [Display(Name = "Mô tả")]
        public string DESCRIPTION { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập mô tả CPU")]
        [Display(Name = "Mô tả CPU")]
        public string DESCRIPTION_CPU { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập mô tả Ram")]
        [Display(Name = "Mô tả CPU")]
        public string DESCRIPTION_RAM { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập mô tả dung lượng")]
        [Display(Name = "Mô tả Dung lượng")]
        public string DESCRIPTION_STORAGE { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập mô tả Card")]
        [Display(Name = "Mô tả Card")]
        public string DESCRIPTION_CARD { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập mô tả khung hình")]
        [Display(Name = "Mô tả Khung hình")]
        public string DESCRIPTION_SCREEN { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập mô tả cân nặng")]
        [Display(Name = "Mô tả Cân nặng")]
        public string DESCRIPTION_WEIGHT { get; set; }

        public string IMAGE { get; set; }
        public int HOTPRODUCT { get; set; }
        

        [NotMapped]
        public HttpPostedFileBase UploadImage { get; set; }
        
    }
    public class UpdateProductInput : CreateProductInput
    {

    }
}