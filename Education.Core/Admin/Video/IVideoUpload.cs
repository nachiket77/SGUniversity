using Education.Entity.Admin;
using Education.Entity.Admin.Videos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Core.Admin
{
   public interface IVideoUpload
    {
        AllVideosDetails CreateVideoDetails(AllVideosDetails VideoDetails);

        List<VideoUploaddetails> GetVideoUploaddetails();
        List<VideoUploaddetails> GetVideoUploaddetails(VideoUploaddetails objvideoDetails);

        List<CourseMaster> GetCourse();

        List<SubjectMaster> Getsubject();

        List<VideoUploaddetails> GetFileName(int FileID);
    }
}
