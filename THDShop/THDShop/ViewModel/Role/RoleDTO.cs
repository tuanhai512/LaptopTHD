using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THDShop.ViewModel.Role
{
    public class RoleDTO
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public List<ROLE> listRole { get; internal set; }

    }
}