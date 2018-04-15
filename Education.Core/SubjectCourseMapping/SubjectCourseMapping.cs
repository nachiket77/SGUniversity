using Education.DB;
using Education.Entity.SubjectCourseMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Core.SubjectCourseMapping
{
    public class SubjectCourseMapping:ISubjectCourseMapping
    {
        public ajay_dbEntities dbEntities = new ajay_dbEntities();

        public bool CreateSubjectCourseMappingDetails(AllSubjectCourseMappingDetails SubjectCourseMappingDetails)
        {
            AllSubjectCourseMappingDetails objsubject = new AllSubjectCourseMappingDetails();
            try
            {
                TBL_MASTER_SUBJECT mastersubject = new TBL_MASTER_SUBJECT();

                mastersubject.NAME = SubjectCourseMappingDetails.SubjectMaster.SUBJECTNAME;
                dbEntities.TBL_MASTER_SUBJECT.Add(mastersubject);
                dbEntities.SaveChanges();
               int subjectid = mastersubject.SUBJECTID;

                TBL_COURSE_SUBJECT_MAPPING_DETAILS coursesubjectmapping = new TBL_COURSE_SUBJECT_MAPPING_DETAILS();
                foreach (var item in SubjectCourseMappingDetails.CourseList)
                {
                    if (item.IsChecked==true)
                    {
                        int CourseId = item.ID;
                        coursesubjectmapping.COURSEID = CourseId;
                    }
                    
                }

                coursesubjectmapping.SUBJECTID = subjectid;
                coursesubjectmapping.CREATEDDATE = DateTime.Now;
                dbEntities.TBL_COURSE_SUBJECT_MAPPING_DETAILS.Add(coursesubjectmapping);
                dbEntities.SaveChanges();

                return true;




            }
            catch (Exception)
            {

                throw;
            }
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

    }
}
