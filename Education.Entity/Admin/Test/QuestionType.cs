using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Entity.Admin.Test
{
  public  class QuestionType
    {
        public int QUESTIONTYPEID
        {
            get;
            set;
        }
        public string TYPENAME
        {
            get;
            set;
        }

        public List<QuestionType> QuestionTypedetails
        {
            get;
            set;
        }
    }
}
