//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Education.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_MASTER_USERTYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_MASTER_USERTYPE()
        {
            this.TBL_USER_LOGIN = new HashSet<TBL_USER_LOGIN>();
            this.TBL_USER_ROLE = new HashSet<TBL_USER_ROLE>();
        }
    
        public int USERTYPEID { get; set; }
        public string TYPENAME { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_USER_LOGIN> TBL_USER_LOGIN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_USER_ROLE> TBL_USER_ROLE { get; set; }
    }
}
