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
    
    public partial class TBL_GN_DIGITALDOC_DETAILS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_GN_DIGITALDOC_DETAILS()
        {
            this.TBL_GN_DIGITALDOC_VIEWDETAILS = new HashSet<TBL_GN_DIGITALDOC_VIEWDETAILS>();
        }
    
        public long DIGITALDOCID { get; set; }
        public Nullable<int> DIGITALDOCTYPEID { get; set; }
        public string DOCUMENTNAME { get; set; }
        public Nullable<int> SUBJECTID { get; set; }
        public Nullable<long> CREATEDBY { get; set; }
        public Nullable<System.DateTime> CREATEDDATE { get; set; }
        public Nullable<long> MODIFIEDBY { get; set; }
        public Nullable<System.DateTime> MODIFIEDDATE { get; set; }
        public Nullable<bool> STATUS { get; set; }
        public Nullable<bool> ALLOWANONYMOUS { get; set; }
        public Nullable<int> DOWNLOADCOUNT { get; set; }
        public Nullable<int> VIEWCOUNT { get; set; }
    
        public virtual TBL_MASTER_SUBJECT TBL_MASTER_SUBJECT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_GN_DIGITALDOC_VIEWDETAILS> TBL_GN_DIGITALDOC_VIEWDETAILS { get; set; }
    }
}
