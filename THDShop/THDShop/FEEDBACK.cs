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
    
    public partial class FEEDBACK
    {
        public int ID { get; set; }
        public int IDCUS { get; set; }
        public Nullable<double> CONTENT { get; set; }
        public Nullable<System.DateTime> DATEFB { get; set; }
    
        public virtual CUSTOMER CUSTOMER { get; set; }
    }
}
