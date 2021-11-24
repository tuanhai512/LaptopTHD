using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace THDShop.ViewModel.DeliAddress
{
    public class CreateDeliAddressInput
    {
        public int ID { get; set; }
        public int IDCustomer { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập tên ")]
        [Display(Name = "Tên sản phẩm")]
        public string NAME { get; set; }

        [StringLength(12, ErrorMessage = "Số điện thoại vượt quá 12 ký tự")]
        [Required(ErrorMessage = "Bạn chưa nhập Số Điện Thoại")]
        [Display(Name = "Số Điện Thoại")]
        public string PHONE { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Địa Chỉ")]
        [Display(Name = "Địa Chỉ")]
        public string ADDRESS { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Phường")]
        [Display(Name = "Phường")]
        public string WARD { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Quận")]
        [Display(Name = "Quận")]
        public string DISTRICT { get; set; }

        public string NOTE { get; set; }
        
    }
}