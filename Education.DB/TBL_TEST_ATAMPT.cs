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
    
    public partial class TBL_TEST_ATAMPT
    {
        public long TESTATAMPTID { get; set; }
        public Nullable<long> TESTID { get; set; }
        public Nullable<long> USERID { get; set; }
        public Nullable<System.DateTime> STARTDATETIME { get; set; }
        public Nullable<System.DateTime> ENDDATETIME { get; set; }
        public Nullable<int> TOTALMARKS { get; set; }
    
        public virtual TBL_TEST_TESTDETAIL TBL_TEST_TESTDETAIL { get; set; }
        public virtual TBL_USER_LOGIN TBL_USER_LOGIN { get; set; }
    }
}
