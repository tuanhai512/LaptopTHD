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
    
    public partial class MYGIFT
    {
        public int ID { get; set; }
        public string IDGIFT { get; set; }
        public int IDCUS { get; set; }
    
        public virtual CUSTOMER CUSTOMER { get; set; }
        public virtual GIFT GIFT { get; set; }
    }
}
