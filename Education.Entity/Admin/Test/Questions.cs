using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Entity.Admin.Test
{
    public class Questions
    {
        public string DESCRIPTION
        {
            get;
            set;
        }
        public int ISMULTISELECT
        {
            get;
            set;
        }

        public int TESTID
        {
            get;
            set;
        }

        public int QUESTIONTYPEID
        {
            get;
            set;
        }

        public int MARKS
        {
            get;
            set;
        }

        public List<Questions> QuestionsDetails
        {
            get;
            set;
        }

    }
}
