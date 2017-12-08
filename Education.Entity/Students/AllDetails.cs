using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Entity.Students
{
  public  class AllDetails
    {
        public StudentDetails StudentDetails { get; set; }
        public ParentDetails ParentDetails { get; set; }

        public ProfessionalDetails ProfessionalDetails { get; set; }

        public CourseMaster CourseMaster { get; set; }

        public List<CourseMaster> CourseList { get; set; }

        public List<StudentDetails> StudentList { get; set; }

        public List<SubjectMaster> subjectList { get; set; }

        public Boards BoardsMaster { get; set; }

        public Classes ClassesMaster { get; set; }
        public List<Boards> BoardsList { get; set; }

        public List<Classes> ClassesList { get; set; }

    }
}
