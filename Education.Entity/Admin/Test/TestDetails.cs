using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Entity.Admin
{
  public class TestDetails
    {
        //public int TESTID { get; set; }
        //public string TITLE { get; set; }

        //public int SUBJECTID { get; set; }
        //public DateTime  PUBLISHDATE { get; set; }

        //public int STATUS { get; set; }
        //public string GIVENBY { get; set; }

        //public string CREATEDBY { get; set; }
        //public DateTime CREATEDDATE { get; set; }

        //public string MODIFIEDBY { get; set; }
        //public DateTime MODIFIEDDATE { get; set; }
        public long TESTID { get; set; }
        public string TITLE { get; set; }
        public Nullable<int> SUBJECTID { get; set; }
        public Nullable<System.DateTime> PUBLISHDATE { get; set; }
        public Nullable<bool> STATUS { get; set; }
        public Nullable<long> GIVENBY { get; set; }
        public Nullable<long> CREATEDBY { get; set; }
        public Nullable<System.DateTime> CREATEDDATE { get; set; }
        public Nullable<long> MODIFIEDBY { get; set; }
        public Nullable<System.DateTime> MODIFIEDDATE { get; set; }


        public long ANSWERID { get; set; }
        public string ANSWERDESCRIPTION { get; set; }
        public Nullable<long> QUESTIONID { get; set; }

        public string QUESTIONDESCRIPTION { get; set; }

        public Nullable<bool> ISVALID { get; set; }

      
        public bool ISMULTISELECT { get; set; }
        
        public int QUESTIONTYPEID { get; set; }
        public int MARKS { get; set; }

        public Nullable<int> COURSEID { get; set; }

        public Nullable<int> TESTTYPEID { get; set; }

    }
}
