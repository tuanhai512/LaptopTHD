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
    
    public partial class BILL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BILL()
        {
            this.DE_BILL = new HashSet<DE_BILL>();
        }
    
        public int ID { get; set; }
        public Nullable<int> IDSTAFF { get; set; }
        public int IDORDER { get; set; }
        public double TOTALMONEY { get; set; }
        public System.DateTime DATETIME { get; set; }
        public string NOTE { get; set; }
        public int METHODS { get; set; }
    
        public virtual ORDER ORDER { get; set; }
        public virtual STAFF STAFF { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DE_BILL> DE_BILL { get; set; }
    }
}
