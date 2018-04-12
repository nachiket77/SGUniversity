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
        int CreateVideoDetails(AllVideosDetails VideoDetails);

        List<VideoUploaddetails> GetVideoUploaddetails();
        List<VideoUploaddetails> GetVideoUploaddetails(VideoUploaddetails objvideoDetails);

        List<CourseMaster> GetCourse();

        List<SubjectMaster> Getsubject();

        List<VideoUploaddetails> GetFileName(int FileID);

        /// Added by Pramod for API
        /// 
        List<VideoUploaddetails> GetVideoUploaddetailsBySubjectId(int? subjectId);

        List<RecommendedVideoModel> GET_RecommendedVideos(int? StudentId);

        List<PopularVideoModel> GET_PopularVideos(int? StudentId);

        VideoDetailsViewModel GET_VideoDetails(long VideoId);


    }
}
