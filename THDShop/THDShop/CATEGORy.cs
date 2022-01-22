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
    using THDShop.ViewModel.Category;
    public interface CategoryPrototype
    {
        CategoryPrototype Clone();

    }

    public partial class CATEGORy : CategoryPrototype
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATEGORy()
        {
            this.PRODUCTS = new HashSet<PRODUCT>();
        }
        public CategoryPrototype Clone()
        {
            CATEGORy cate = new CATEGORy();
            cate.NAME = NAME;
            cate.CREATEAT = DateTime.Now;
            return cate;
        }
        public int ID { get; set; }
        public string NAME { get; set; }
        public Nullable<int> CREATEBY { get; set; }
        public System.DateTime CREATEAT { get; set; }
        public Nullable<int> UPDATEBY { get; set; }
        public Nullable<System.DateTime> UPDATEAT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCT> PRODUCTS { get; set; }
    }
}
