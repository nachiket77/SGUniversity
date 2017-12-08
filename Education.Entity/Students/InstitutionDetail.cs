using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Entity.Students
{
  public  class InstitutionDetail
    {
        public long INSTITUTIONID { get; set; }
        public string INSTITUTIONNAME { get; set; }
        public Nullable<long> USERID { get; set; }
        public Nullable<int> CLASSID { get; set; }
        public int BOARDID { get; set; }
        public Nullable<int> PASSINGYEAR { get; set; }
        public string GRADE_PERCENT { get; set; }
        public Nullable<long> CREATEDBY { get; set; }
        public Nullable<System.DateTime> CREATEDDATE { get; set; }
        public Nullable<long> MODIFIEDBY { get; set; }
        public Nullable<System.DateTime> MODIFIEDDATE { get; set; }
    }
}
