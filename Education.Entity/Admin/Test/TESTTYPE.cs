using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Entity.Admin.Test
{
   public class TESTTYPE
    {
        public int TESTTYPEID
        {
            get;
            set;
        }
        public string TESTTYPENAME
        {
            get;
            set;
        }

        public List<TESTTYPE> TestTypedetails
        {
            get;
            set;
        }

    }
}
