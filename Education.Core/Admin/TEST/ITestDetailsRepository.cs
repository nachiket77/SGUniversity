using Education.Entity.Admin;
using Education.Entity.Admin.Test;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Core.Admin
{
    public interface ITestDetailsRepository
    {
        AllTestDetails CreateTestDetails(DataSet studentDetails,AllTestDetails TestDetails);

        List<CourseMaster> GetCourse();

        List<SubjectMaster> Getsubject();

        List<TESTTYPE> GetTestType();

        List<QuestionType> GetQuestionType();

        List<TestDetails> GetTestDetails();

        

    }
}
