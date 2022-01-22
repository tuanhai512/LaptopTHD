
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace THDShop.ViewModel.User
{
    public class CreateUserInput
    {
        public CreateUserInput()
        {
            AVATAR = "~/Assets/Images/upload.png";
        }
        public int ID { get; set; }

        public int IDCUS { get; set; }
        [Required]
        [Display(Name = "Nhap ten")]
        public string NAME { get; set; }
        [Required]
        [Display(Name = "Nhap Pass")]
        public string PASSWORD { get; set; }

        [Required]
        [Display(Name = "Nhap dia chi")]
        public string ADDRESS { get; set; }

        [Required]
        [Display(Name = "Nhap sdt lien lac")]
        public string PHONE { get; set; }
        [Required]
        [Display(Name = "Nhap email lien lac")]
        public string EMAIL { get; set; }
        public string AVATAR { get; set; }
        public string ROLENAME { get; set; }
        public int? IDROLE { get; set; }
        [NotMapped]
        [Compare("PASSWORD")]
        public string CONFIRM { get; set; }

        [NotMapped]
        public HttpPostedFileBase UploadImage { get; set; }

    }
    public class UpdateUserInput : CreateUserInput
    {
        //public int ID { get; set; }

        //[Required]
        //[Display(Name = "Nhap ten")]
        //public string NAME { get; set; }
        //[Required]
        //[Display(Name = "Nhap Pass")]
        //public string PASSWORD { get; set; }

        //[Required]
        //[Display(Name = "Nhap dia chi")]
        //public string ADDRESS { get; set; }

        //[Required]
        //[Display(Name = "Nhap sdt lien lac")]
        //public string PHONE { get; set; }
        //[Required]
        //[Display(Name = "Nhap email lien lac")]
        //public string EMAIL { get; set; }
        //public string AVATAR { get; set; }
        //public int IDROLE { get; set; }

        //[NotMapped]
        //[Compare("PASSWORD")]

        //public string CONFIRM { get; set; }
        //public virtual ROLE ROLE { get; set; }
    }
}