using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Entity.Admin.Test
{
  public  class Answer
    {
        public string DESCRIPTION
        {
            get;
            set;
        }
        public int ANSWERID
        {
            get;
            set;
        }

        public int QUESTIONID
        {
            get;
            set;
        }

        public int TESTID
        {
            get;
            set;
        }

        public int ISVALID
        {
            get;
            set;
        }

        public List<Answer> AnswerDetails
        {
            get;
            set;
        }

    }
}
