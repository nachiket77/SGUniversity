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
    
    public partial class TBL_USER_SUBJECTS
    {
        public long USERSUBJECTID { get; set; }
        public Nullable<int> SUBJECTID { get; set; }
        public Nullable<long> USERID { get; set; }
        public Nullable<long> CREATEDBY { get; set; }
        public Nullable<System.DateTime> CREATEDDATE { get; set; }
        public Nullable<long> MODIFIEDBY { get; set; }
        public Nullable<System.DateTime> MODIFIEDDATE { get; set; }
    
        public virtual TBL_MASTER_SUBJECT TBL_MASTER_SUBJECT { get; set; }
        public virtual TBL_USER_LOGIN TBL_USER_LOGIN { get; set; }
    }
}