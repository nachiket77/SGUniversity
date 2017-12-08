using Education.Entity.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Core.Students
{
    public interface IStudentReposetory
    {
        AllDetails CreateStudent(AllDetails studentDetails);

        AllDetails CreateParentDetails(AllDetails studentDetails);

        AllDetails CreateProfessionalDetails(AllDetails studentDetails);
        bool StudentExist(StudentDetails student);
        List<InstitutionDetail> GetInstitutes(long UserID);
        InstitutionDetail AddInstitute(InstitutionDetail Institute);
        bool DeleteInstitute(long InstituteID);
        List<Boards> GetBoards();
        List<Classes> GetClasses();
        List<Documents> GetDocuments(long UserID);

        List<CourseMaster> GetCourse();

        List<StudentDetails> GetStudentDetails();

        List<SubjectMaster> Getsubject();

        void updateStudentDetail(int userid, string FirstName, string Last, string middle);

    }
}
