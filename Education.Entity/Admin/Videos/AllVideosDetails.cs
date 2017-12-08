using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Entity.Admin.Videos
{
   public class AllVideosDetails
    {
        public VideoUploaddetails VideoUploaddetails { get; set; }

        public List<VideoUploaddetails> VideoUploaddetailsList { get; set; }


        public CourseMaster CourseMaster { get; set; }

        public List<CourseMaster> CourseList { get; set; }

        public SubjectMaster SubjectMaster { get; set; }

        public List<SubjectMaster> SubjectList { get; set; }
    }
}
