using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THDShop.ViewModel
{
    public class Staff
    {
        public int ID { get; set; }
        public int IDUSER { get; set; }
        public string NAME { get; set; }
        public string PHONE { get; set; }
        public string ADDRESS { get; set; }
        public Nullable<System.DateTime> BRITHDAY { get; set; }
        public string EMAIL { get; set; }
        public string PASSWORD { get; set; }
        public string AVATAR { get; set; }
        public Nullable<int> IDROLES { get; set; }
    }
}