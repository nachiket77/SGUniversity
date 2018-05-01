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

        // Created by Pramod for API
        List<TestTypeModel> GetTestDetailsForAPI(Nullable<int> StudentId);
        List<TestQuestion> GetTestQuestionForAPI(int testId);
        TestProgressModel SaveTestAnswers(int testId, int subjectId, DateTime startTime, DateTime endTime, int studentId, string quesAnsXml);
        List<TestQuestionAns> GetTestQuestionAnsForAPI(int testId,int StudentId);
    }
}
