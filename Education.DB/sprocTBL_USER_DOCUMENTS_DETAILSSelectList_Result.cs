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
    
    public partial class sprocTBL_USER_DOCUMENTS_DETAILSSelectList_Result
    {
        public long USERDOCUMENTID { get; set; }
        public Nullable<int> DOCUMENTTYPEID { get; set; }
        public string DOCUMENTNAME { get; set; }
        public long USERID { get; set; }
        public Nullable<bool> STATUS { get; set; }
        public Nullable<long> CREATEDBY { get; set; }
        public Nullable<System.DateTime> CREATEDDATE { get; set; }
        public Nullable<long> MODIFIEDBY { get; set; }
        public Nullable<System.DateTime> MODIFIEDDATE { get; set; }
    }
}
