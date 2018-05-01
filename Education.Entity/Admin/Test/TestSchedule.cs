using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Entity.Admin.Test
{
    #region Test Schedule
    public class TestScheduleDetails
    {
        public long TestId { get; set; }
        public string Title { get; set; }
        public Nullable<DateTime> PublishDate { get; set; }
        public Nullable<int> TotalQuestion { get; set; }
        public Nullable<int> TotalMarks { get; set; }
        public Nullable<int> SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Nullable<bool> Status { get; set; }
        public int TestTypeId { get; set; }
        public string TestTypeName { get; set; }
        public string TotalTime { get; set; }

    }

    public class TestAttamptedDetails
    {
        public long TestId { get; set; }
        public string Title { get; set; }
        public Nullable<DateTime> PublishDate { get; set; }
        public Nullable<int> SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Nullable<bool> Status { get; set; }
        public int TestTypeId { get; set; }
        public string TestTypeName { get; set; }
        public int TotalAttamptedQues { get; set; }
        public decimal? ObtainedPer { get; set; }
    }

    public class TestSchedule
    {
        public Nullable<int> SubjectId { get; set; }
        public string SubjectName { get; set; }
        public List<TestScheduleDetails> TDetails { get; set; }

    }
    public class TestAttampted
    {
        public Nullable<int> SubjectId { get; set; }
        public string SubjectName { get; set; }
        public List<TestAttamptedDetails> TDetails { get; set; }

    }

    public class TestTypeModel
    {
        public string TestType { get; set; }
        public dynamic Data { get; set; }
    }
    #endregion

    #region Test Question Answer

    public class TestQuestionDetails
    {
        public long QuestionId { get; set; }
        public string Question { get; set; }
        public int Marks { get; set; }
        public decimal NegativeMarks { get; set; }
        public long AnswerId { get; set; }
        public string Answer { get; set; }
        public long TestId { get; set; }
        public string Title { get; set; }
        public Nullable<int> SubjectId { get; set; }
    }

    public class TestQuestion
    {
        public long TestId { get; set; }
        public string Title { get; set; }
        public Nullable<int> SubjectId { get; set; }
        public int Marks { get; set; }
        public decimal NegativeMarks { get; set; }
        public long QuestionId { get; set; }
        public string Question { get; set; }
        public List<TestAnswer> TAnswer { get; set; }
    }

    public class TestQuestionAnsDetails
    {
        public long QuestionId { get; set; }
        public string Question { get; set; }
        public int Marks { get; set; }
        public decimal? NegativeMarks { get; set; }
        public long AnswerId { get; set; }
        public string Answer { get; set; }
        public long TestId { get; set; }
        public string Title { get; set; }
        public Nullable<int> SubjectId { get; set; }
        public long ValidAnswer { get; set; }
        public long? AttamptedAns { get; set; }
    }

    public class TestQuestionAns
    {
        public long TestId { get; set; }
        public string Title { get; set; }
        public Nullable<int> SubjectId { get; set; }
        public int Marks { get; set; }
        public decimal? NegativeMarks { get; set; }
        public long QuestionId { get; set; }
        public string Question { get; set; }
        public List<TestAnswer> TAnswer { get; set; }
        public long ValidAnswer { get; set; }
        public long? AttamptedAns { get; set; }
    }

    public class TestAnswer
    {
        public long AnswerId { get; set; }
        public string Answer { get; set; }
        // public long QuestionId { get; set; }

    }


    #endregion

    public class Test
    {
        public int TestId { get; set; }
    }

    public class TestAns
    {
        public int TestId { get; set; }
        public int StudentId { get; set; }
    }


    #region TestAnswer

    public class TestAnswerModel
    {
        public int TestId { get; set; }
        public int SubjectId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int StudentId { get; set; }
        public List<AnswerModel> lstQuesAns { get; set; }
    }

    public class AnswerModel
    {
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public string Remark { get; set; }
    }

    public class TestProgressModel
    {
        public Nullable<int> TotalQues { get; set; }
        public Nullable<int> Correct { get; set; }
        public Nullable<int> Incorrect { get; set; }
        public Nullable<int> Unanswered { get; set; }
        public Nullable<int> TestId { get; set; }
        public Nullable<int> StudentId { get; set; }

    }
    #endregion


}
