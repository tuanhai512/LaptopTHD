using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace THDShop.Areas.Manager.Controllers
{
    public abstract class State_Changes_Status
    {
        public abstract void Change_Status(int? id);
    }
    public class Confirm : State_Changes_Status
    {
        public override void Change_Status(int? id)
        {
            ORDER dathang = new ORDER();
            dathang.STATUS = 1;
        }
    }
    public class Success : State_Changes_Status
    {
        public override void Change_Status(int? id)
        {
            ORDER dathang = new ORDER();
            dathang.STATUS =2;
        }
    }
    public class Cancel : State_Changes_Status
    {
        public override void Change_Status(int? id)
        {
            ORDER dathang = new ORDER();
            dathang.STATUS = 3;
        }
    }

}

       
    
    
