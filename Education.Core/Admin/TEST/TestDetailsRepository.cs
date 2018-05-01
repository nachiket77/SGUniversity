using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Entity.Admin;
using Education.DB;
using System.Data;
using Education.Entity.Admin.Test;

namespace Education.Core.Admin
{
    public class TestDetailsRepository : ITestDetailsRepository
    {
        public ajay_dbEntities dbEntities = new ajay_dbEntities();

        public AllTestDetails CreateTestDetails(DataSet studentDetails, AllTestDetails allTestDetails)
        {
            TBL_TEST_TESTDETAIL objtestdetails = new TBL_TEST_TESTDETAIL();
            objtestdetails.TITLE = allTestDetails.TestDetails.TITLE;
            objtestdetails.SUBJECTID = allTestDetails.SubjectMaster.SUBJECTID;
            objtestdetails.TESTTYPEID = allTestDetails.TestTypeMaster.TESTTYPEID;
            objtestdetails.COURSEID = allTestDetails.CourseMaster.ID;
            objtestdetails.TOTALMARKS = allTestDetails.TestDetails.TotalMarks;
            objtestdetails.TOTALTIME = allTestDetails.TestDetails.TotalTime;
            objtestdetails.PUBLISHDATE = DateTime.Now;
            objtestdetails.GIVENBY = allTestDetails.TestDetails.GIVENBY;
            objtestdetails.CREATEDDATE = DateTime.Now;

            dbEntities.TBL_TEST_TESTDETAIL.Add(objtestdetails);
            dbEntities.SaveChanges();
            allTestDetails.TestDetails.TESTID = objtestdetails.TESTID;





            foreach (DataTable table in studentDetails.Tables)
            {
                foreach (DataRow dr in table.Rows)
                {
                    //foreach (var item in dr.ItemArray)
                    //{

                    string questions = Convert.ToString(dr["Questions"].ToString());
                    string answers = Convert.ToString(dr["Answers"].ToString());
                    int Isvalid = Convert.ToInt16(dr["Isvalid"].ToString());
                    int Marks = Convert.ToInt16(dr["Marks"].ToString());

                    TBL_TEST_QUESTIONS objquestiondetails = new TBL_TEST_QUESTIONS();

                    objquestiondetails.DESCRIPTION = questions;
                    objquestiondetails.ISMULTISELECT = true;
                    objquestiondetails.TESTID = allTestDetails.TestDetails.TESTID;
                    objquestiondetails.QUESTIONTYPEID = allTestDetails.QuestionTypeMaster.QUESTIONTYPEID;
                    objquestiondetails.MARKS = Marks;
                    dbEntities.TBL_TEST_QUESTIONS.Add(objquestiondetails);
                    dbEntities.SaveChanges();
                    allTestDetails.TestDetails.QUESTIONID = objquestiondetails.QUESTIONID;


                    TBL_TEST_ANSWERS objtestanswersdetail = new TBL_TEST_ANSWERS();
                    objtestanswersdetail.DESCRIPTION = answers;
                    objtestanswersdetail.QUESTIONID = allTestDetails.TestDetails.QUESTIONID;
                    objtestanswersdetail.TESTID = allTestDetails.TestDetails.TESTID;
                    objtestanswersdetail.ISVALID = Convert.ToBoolean(Isvalid);



                    //dbEntities.TBL_TEST_TESTDETAIL.Add(objtestdetails);
                    //dbEntities.TBL_TEST_QUESTIONS.Add(objquestiondetails);
                    dbEntities.TBL_TEST_ANSWERS.Add(objtestanswersdetail);
                    dbEntities.SaveChanges();
                    // }
                }
            }

            return allTestDetails;
        }

        public List<CourseMaster> GetCourse()
        {
            try
            {
                List<CourseMaster> Coursedetails = new List<CourseMaster>();

                return dbEntities.TBL_MASTER_COURSE.Select(X => new CourseMaster() { NAME = X.NAME, ID = X.COURSEID }).ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<QuestionType> GetQuestionType()
        {
            try
            {
                List<QuestionType> QuestionTypedetails = new List<QuestionType>();

                return dbEntities.TBL_MASTER_TESTQUESTIONTYPE.Select(X => new QuestionType() { QUESTIONTYPEID = X.QUESTIONTYPEID, TYPENAME = X.TYPENAME }).ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<SubjectMaster> Getsubject()
        {
            try
            {
                List<SubjectMaster> Subjectdetails = new List<SubjectMaster>();

                return dbEntities.TBL_MASTER_SUBJECT.Select(X => new SubjectMaster() { SUBJECTNAME = X.NAME, SUBJECTID = X.SUBJECTID }).ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TestDetails> GetTestDetails()
        {
            try
            {
                return dbEntities.TBL_TEST_TESTDETAIL.OrderByDescending(x => x.TESTID).Select(X => new TestDetails() { TESTID = (X.TESTID), TITLE = X.TITLE, SUBJECTID = X.SUBJECTID, COURSEID = X.COURSEID, PUBLISHDATE = X.PUBLISHDATE }).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<TESTTYPE> GetTestType()
        {
            try
            {
                List<TESTTYPE> TESTTYPEdetails = new List<TESTTYPE>();

                return dbEntities.TBL_MASTER_TEST_TYPE.Select(X => new TESTTYPE() { TESTTYPENAME = X.TESTTYPENAME, TESTTYPEID = X.TESTTYPEID }).ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        // Added by Pramod for API
        public List<TestTypeModel> GetTestDetailsForAPI(Nullable<int> StudentId)
        {
            List<TestSchedule> testSchedule = new List<TestSchedule>();
            var testDetails = (from a in dbEntities.USP_GET_TestDetails(StudentId)
                               select new TestScheduleDetails
                               {
                                   PublishDate = a.PublishDate,
                                   Status = a.Status,
                                   SubjectId = a.SubjectId,
                                   SubjectName = a.SubjectName,
                                   TestId = a.TestId,
                                   TestTypeId = a.TestTypeId,
                                   TestTypeName = a.TestTypeName,
                                   Title = a.Title,
                                   TotalMarks = a.TotalMarks,
                                   TotalQuestion = a.TotalQuestion,
                                   TotalTime = a.TotalTime


                               }).ToList();

            var ts = (from a in testDetails
                      group a by a.SubjectId into temp
                      select new
                      {
                          subjectId = temp.Key,
                          subjectName = temp.Max(g => g.SubjectName)
                      }).ToList();


            testSchedule = (from a in ts
                            select new TestSchedule
                            {
                                SubjectId = a.subjectId,
                                SubjectName = a.subjectName,
                                TDetails = testDetails.Where(t => t.SubjectId == a.subjectId).ToList()
                            }).ToList();

            // For Attampted Questions

            var attTestDetails = (from a in dbEntities.USP_GET_Attampted_TestDetails(StudentId)
                                  select new TestAttamptedDetails
                                  {
                                      PublishDate = a.PublishDate,
                                      Status = a.Status,
                                      SubjectId = a.SubjectId,
                                      SubjectName = a.SubjectName,
                                      TestId = a.TestId,
                                      TestTypeId = a.TestTypeId,
                                      TestTypeName = a.TestTypeName,
                                      Title = a.Title,
                                      ObtainedPer = a.ObtainedPer,
                                      TotalAttamptedQues = a.TotalAttamptedQues

                                  }).ToList();

            var attTs = (from a in attTestDetails
                      group a by a.SubjectId into temp
                      select new
                      {
                          subjectId = temp.Key,
                          subjectName = temp.Max(g => g.SubjectName)
                      }).ToList();


            List<TestAttampted> testAttampted = new List<TestAttampted>();
            testAttampted = (from a in attTs
                             select new TestAttampted
                             {
                                 SubjectId = a.subjectId,
                                 SubjectName = a.subjectName,
                                 TDetails = attTestDetails.Where(t => t.SubjectId == a.subjectId).ToList()
                             }).ToList();

            List<TestTypeModel> lstTestTypeModel = new List<TestTypeModel>();
            TestTypeModel model = new TestTypeModel();
            model.TestType = "Upcoming";
            model.Data = testSchedule;
            lstTestTypeModel.Add(model);

            model = new TestTypeModel();
            model.TestType = "Attempted";
            model.Data = testAttampted;
            lstTestTypeModel.Add(model);

            return lstTestTypeModel;
        }

        public List<TestQuestion> GetTestQuestionForAPI(int testId)
        {
            List<TestQuestion> testQuestion = new List<TestQuestion>();
            var testQuestionDetails = (from a in dbEntities.USP_GET_TestQuestionByTestId(testId)
                                       select new TestQuestionDetails
                                       {
                                           TestId = a.TestId,
                                           Title = a.Title,
                                           SubjectId = a.SubjectId,
                                           QuestionId = a.QuestionId,
                                           Question = a.Question,
                                           AnswerId = a.AnswerId,
                                           Answer = a.Answer,
                                           Marks = a.Marks,
                                           NegativeMarks = a.NegativeMarks
                                       }).ToList();

            testQuestion = (from a in testQuestionDetails
                            group a by a.QuestionId into temp
                            select new TestQuestion
                            {
                                TestId = temp.Max(g => g.TestId),
                                Title = temp.Max(g => g.Title),
                                SubjectId = temp.Max(g => g.SubjectId),
                                Marks = temp.Max(g => g.Marks),
                                NegativeMarks = temp.Max(g => g.NegativeMarks),
                                QuestionId = temp.Key,
                                Question = temp.Max(g => g.Question),
                                TAnswer = (from t in testQuestionDetails where (t.QuestionId == temp.Key) select new TestAnswer { Answer = t.Answer, AnswerId = t.AnswerId }).ToList()


                            }).ToList();

            return testQuestion;


        }

        public TestProgressModel SaveTestAnswers(int testId, int subjectId, DateTime startTime, DateTime endTime, int studentId, string quesAnsXml)
        {

            TestProgressModel model = (from a in dbEntities.USP_SaveTestAnswers(testId, subjectId, startTime, endTime, studentId, quesAnsXml)
                                       select new TestProgressModel
                                       {
                                           Correct = a.Correct,
                                           Incorrect = a.Incorrect,
                                           StudentId = a.StudentId,
                                           TestId = a.TestId,
                                           TotalQues = a.TotalQues,
                                           Unanswered = a.Unanswered
                                       }).FirstOrDefault();
            return model;

        }

        public List<TestQuestionAns> GetTestQuestionAnsForAPI(int testId, int studentId)
        {
            List<TestQuestionAns> testQuestionAns = new List<TestQuestionAns>();
            var testQuestionAndDetails = (from a in dbEntities.USP_GET_TestQuesANSByTestId(testId, studentId)
                                          select new TestQuestionAnsDetails
                                          {
                                              TestId = a.TestId,
                                              Title = a.Title,
                                              SubjectId = a.SubjectId,
                                              QuestionId = a.QuestionId,
                                              Question = a.Question,
                                              AnswerId = a.AnswerId,
                                              Answer = a.Answer,
                                              Marks = a.Marks,
                                              NegativeMarks = a.NegativeMarks,
                                              ValidAnswer = a.ValidAnswer,
                                              AttamptedAns = a.AttamptedAns
                                          }).ToList();

            testQuestionAns = (from a in testQuestionAndDetails
                               group a by a.QuestionId into temp
                               select new TestQuestionAns
                               {
                                   TestId = temp.Max(g => g.TestId),
                                   Title = temp.Max(g => g.Title),
                                   SubjectId = temp.Max(g => g.SubjectId),
                                   Marks = temp.Max(g => g.Marks),
                                   NegativeMarks = temp.Max(g => g.NegativeMarks),
                                   QuestionId = temp.Key,
                                   Question = temp.Max(g => g.Question),
                                   TAnswer = (from t in testQuestionAndDetails where (t.QuestionId == temp.Key) select new TestAnswer { Answer = t.Answer, AnswerId = t.AnswerId }).ToList(),
                                   ValidAnswer = temp.Max(g => g.ValidAnswer),
                                   AttamptedAns = temp.Max(g => g.AttamptedAns)


                               }).ToList();

            return testQuestionAns;


        }
    }
}
