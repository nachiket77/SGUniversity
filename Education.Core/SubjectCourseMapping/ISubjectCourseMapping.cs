using Education.Entity.SubjectCourseMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Core.SubjectCourseMapping
{
    public interface ISubjectCourseMapping
    {
        bool CreateSubjectCourseMappingDetails(AllSubjectCourseMappingDetails SubjectCourseMappingDetails);
        List<CourseMaster> GetCourse();

        List<SubjectMaster> Getsubject();

    }
}
