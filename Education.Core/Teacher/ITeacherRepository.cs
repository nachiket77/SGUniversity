using Education.Entity.Teachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Core.Teacher
{
  public interface ITeacherRepository
    {
        AllTeacherDetails CreateTeacher(AllTeacherDetails TeacherDetailsDetails);

        List<CourseMaster> GetCourse();

        List<SubjectMaster> Getsubject();

        bool TeacherExist(TeacherDetails teacher);

        List<TeacherDetails> GetteacherDetails();

        void updateteacherDetail(int userid, string FirstName, string Last, string middle);
    }
}
