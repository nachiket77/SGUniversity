using Education.Entity.Master;
using Education.Entity.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Core.Admin.Master
{
    public interface ICourse
    {
        CourseMaster CreateCourseDetails(CourseMaster CourseDetails);

        List<CourseMaster> GetCourse();
    }
}
