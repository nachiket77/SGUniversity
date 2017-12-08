using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Entity.Master;
using Education.DB;
using Education.Entity.Students;

namespace Education.Core.Admin.Master
{
    public class Course : ICourse
    {
        public ajay_dbEntities dbEntities = new ajay_dbEntities();
        public CourseMaster CreateCourseDetails(CourseMaster objCourseDetails)
        {
            try
            {
                TBL_MASTER_COURSE Coursedetails = new TBL_MASTER_COURSE();
                Coursedetails.NAME = objCourseDetails.NAME;
                dbEntities.TBL_MASTER_COURSE.Add(Coursedetails);
                dbEntities.SaveChanges();
                return objCourseDetails;
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
                List<CourseMaster> Subjectdetails = new List<CourseMaster>();

                return dbEntities.TBL_MASTER_COURSE.Select(X => new CourseMaster() { NAME = X.NAME,ID=X.COURSEID }).ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
