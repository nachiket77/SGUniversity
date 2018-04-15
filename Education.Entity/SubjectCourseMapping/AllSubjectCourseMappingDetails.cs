using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Entity.SubjectCourseMapping
{
  public  class AllSubjectCourseMappingDetails
    {
        public  SubjectCourseMappingDetails subjectCourseMappingDetails { get; set; }

        public List<SubjectCourseMappingDetails> subjectCourseMappingDetailsList { get; set; }
        public CourseMaster CourseMaster { get; set; }

        public List<CourseMaster> CourseList { get; set; }

        public SubjectMaster SubjectMaster { get; set; }

        public List<SubjectMaster> SubjectList { get; set; }


    }
}
