//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace THDShop
{
    using System;
    using System.Collections.Generic;
    
    public partial class REPORT
    {
        public int ID { get; set; }
        public int IDBILL { get; set; }
        public double TOTALMONEY { get; set; }

        public System.DateTime DATERP { get; set; }
        public double Tongdoanhthu()
        {
            var tdt = TOTALMONEY - BILL.ORI_PRICE;
            return (int)tdt;
        }

        public virtual BILL BILL { get; set; }
    }
}
