using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Entity.Admin.Test
{
    public class AllTestDetails
    {
        public TestDetails TestDetails { get; set; }


        public CourseMaster CourseMaster { get; set; }

        public List<CourseMaster> CourseList { get; set; }

        public SubjectMaster SubjectMaster { get; set; }

        public List<SubjectMaster> SubjectList { get; set; }


        public Questions QuestionMaster { get; set; }

        public List<Questions> QuestionList { get; set; }


        public Answer AnswerMaster { get; set; }

        public List<Answer> AnswerList { get; set; }

        public TESTTYPE TestTypeMaster { get; set; }

        public List<TESTTYPE> TestTypeList { get; set; }

        public QuestionType QuestionTypeMaster { get; set; }

        public List<QuestionType> QuestionTypeList { get; set; }

        public List<TestDetails> TestDetailsList { get; set; }


    }
}
