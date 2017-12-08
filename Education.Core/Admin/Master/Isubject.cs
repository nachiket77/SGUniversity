using Education.Entity.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Core.Admin.Master
{
   public interface Isubject
    {
        SubjectMaster CreateSubjectDetails(SubjectMaster Subjectdetails);

        List<SubjectMaster> GetSubject();
    }
}
