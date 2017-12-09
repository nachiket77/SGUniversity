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

                return dbEntities.TBL_MASTER_TEST_TYPE.Select(X => new TESTTYPE() {  TESTTYPENAME= X.TESTTYPENAME, TESTTYPEID = X.TESTTYPEID }).ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
