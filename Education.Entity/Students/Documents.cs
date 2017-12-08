using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Entity.Students
{
   public class Documents
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
        public string DOCUMENTTYPENAME { get; set; }
    }
}
