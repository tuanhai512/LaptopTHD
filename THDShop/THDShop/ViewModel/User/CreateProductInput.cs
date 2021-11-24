
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace THDShop.ViewModel.User
{
    public class CreateUsertInput
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public string PASSWORD { get; set; }
        public string ADDRESS { get; set; }
        public string PHONE { get; set; }
        public string EMAIL { get; set; }
        public string AVATAR { get; set; }
    }
    public class UpdateProductInput : CreateUsertInput
    {
     
    }
}