using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Entity.Master;
using Education.DB;

namespace Education.Core.Admin.Master
{
    public class Subject : Isubject
    {
        public ajay_dbEntities dbEntities = new ajay_dbEntities();
        public SubjectMaster CreateSubjectDetails(SubjectMaster ObjSubjectdetails)
        {
            try
            {
                TBL_MASTER_SUBJECT Subjectdetails = new TBL_MASTER_SUBJECT();
                Subjectdetails.NAME = ObjSubjectdetails.subjectName;
                dbEntities.TBL_MASTER_SUBJECT.Add(Subjectdetails);
                dbEntities.SaveChanges();
                return ObjSubjectdetails;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<SubjectMaster> GetSubject()
        {
            try
            {
                List<SubjectMaster> Subjectdetails = new List<SubjectMaster>();

                return dbEntities.TBL_MASTER_SUBJECT.Select(X => new SubjectMaster() { subjectName = X.NAME }).ToList();
               
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
