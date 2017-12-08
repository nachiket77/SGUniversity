using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Entity.Teachers;
using Education.DB;

namespace Education.Core.Teacher
{
    public class TeacherRepository : ITeacherRepository
    {
        public ajay_dbEntities dbEntities = new ajay_dbEntities();
        public bool TeacherExist(TeacherDetails Teacher)
        {
            bool result = false;
            if (dbEntities.TBL_MASTER_TEACHER.Count(X => X.EMAILID.ToLower() == Teacher.EMAILID.ToLower() || X.MOBILENUMBER == Teacher.MOBILENUMBER) > 0)
            {
                result = true;
            }
            return result;


        }

        public AllTeacherDetails CreateTeacher(AllTeacherDetails allteacherdetails)
        {
            TBL_MASTER_TEACHER teacherdetails = new TBL_MASTER_TEACHER();

            teacherdetails.FIRSTNAME = allteacherdetails.teacherdetails.FIRSTNAME;
            teacherdetails.MIDDLENAME = allteacherdetails.teacherdetails.MIDDLENAME;
            teacherdetails.LASTNAME = allteacherdetails.teacherdetails.LASTNAME;
            teacherdetails.EMAILID = allteacherdetails.teacherdetails.EMAILID;
            teacherdetails.MOBILENUMBER = allteacherdetails.teacherdetails.MOBILENUMBER;
            teacherdetails.COURSEID = allteacherdetails.teacherdetails.COURSEID;
            teacherdetails.SUBJECTID = allteacherdetails.teacherdetails.SUBJECTID;
            teacherdetails.CREATEDBY = "";
            teacherdetails.CREATEDDATE = DateTime.Now;


            dbEntities.TBL_MASTER_TEACHER.Add(teacherdetails);
            dbEntities.SaveChanges();
            allteacherdetails.teacherdetails.TEACHERID = Convert.ToInt16(teacherdetails.TEACHERID);
            TBL_TEACHER_COURSE_MAPPING_DETAILS objteacherCoursemapping = new TBL_TEACHER_COURSE_MAPPING_DETAILS();
            TBL_TEACHER_SUBJECT_MAPPING_DETAILS objteacherubjectmapping = new TBL_TEACHER_SUBJECT_MAPPING_DETAILS();
            foreach (var course in allteacherdetails.CourseList)
            {
                if (course.IsChecked == true)
                {
                    objteacherCoursemapping.COURSEID = course.ID;
                    objteacherCoursemapping.TEACHERID = teacherdetails.TEACHERID;
                    objteacherCoursemapping.CREATEDDATE = DateTime.Now;
                    dbEntities.TBL_TEACHER_COURSE_MAPPING_DETAILS.Add(objteacherCoursemapping);
                    dbEntities.SaveChanges();
                }

            }

            foreach (var subject in allteacherdetails.SubjectList)
            {
                if (subject.IsChecked == true)
                {
                    objteacherubjectmapping.SUBJECTID = subject.SUBJECTID;
                    objteacherubjectmapping.TEACHERID = teacherdetails.TEACHERID;
                    objteacherubjectmapping.CREATEDDATE = DateTime.Now;
                    dbEntities.TBL_TEACHER_SUBJECT_MAPPING_DETAILS.Add(objteacherubjectmapping);
                    dbEntities.SaveChanges();
                }
            }

            //allteacherdetails.teacherdetails.TEACHERID = teacherdetails.TEACHERID;


            return allteacherdetails;
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
