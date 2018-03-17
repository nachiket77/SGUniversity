using Education.DB;
using Education.Entity.Admin;
using Education.Entity.Admin.Videos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Core.Admin
{
    public class VideoUpload : IVideoUpload
    {
        public ajay_dbEntities dbEntities = new ajay_dbEntities();
        // public TeacherDBEntities dbEntities = new TeacherDBEntities();
        public int CreateVideoDetails(AllVideosDetails objvideoDetails)
        {
            try
            {
                TBL_GN_DIGITALDOC_DETAILS videodetails = new TBL_GN_DIGITALDOC_DETAILS();
                //videodetails.DIGITALDOCTYPEID = objvideoDetails.VideoUploaddetails.DIGITALDOCTYPEID;
                videodetails.DOCUMENTNAME = objvideoDetails.VideoUploaddetails.DOCUMENTNAME;
                videodetails.SUBJECTID = objvideoDetails.VideoUploaddetails.SUBJECTID;

                //videodetails.CREATEDBY = objvideoDetails.VideoUploaddetails.CREATEDBY;
                videodetails.CREATEDDATE = DateTime.Now;
                videodetails.VideoPath = objvideoDetails.VideoUploaddetails.VideoPath;
                //videodetails.MODIFIEDBY = objvideoDetails.VideoUploaddetails.MODIFIEDBY;
                //videodetails.MODIFIEDDATE = objvideoDetails.VideoUploaddetails.MODIFIEDDATE;
                //videodetails.STATUS = objvideoDetails.VideoUploaddetails.STATUS;
                //videodetails.ALLOWANONYMOUS = objvideoDetails.VideoUploaddetails.ALLOWANONYMOUS;
                //videodetails.DOWNLOADCOUNT = objvideoDetails.VideoUploaddetails.DOWNLOADCOUNT;
                //videodetails.VIEWCOUNT = objvideoDetails.VideoUploaddetails.VIEWCOUNT;

                videodetails.CourseId = objvideoDetails.VideoUploaddetails.CourseId;
                videodetails.VideoDesc = objvideoDetails.VideoUploaddetails.VideoDesc;
                videodetails.RefDocs = objvideoDetails.VideoUploaddetails.RefDocumentPath;

                videodetails.STATUS = true;
                videodetails.CREATEDBY = objvideoDetails.VideoUploaddetails.CREATEDBY;

                dbEntities.TBL_GN_DIGITALDOC_DETAILS.Add(videodetails);
               return dbEntities.SaveChanges();
                //return objvideoDetails;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<VideoUploaddetails> GetFileName(int FileID)
        {
            try
            {
                return dbEntities.TBL_GN_DIGITALDOC_DETAILS.Where(X => X.DIGITALDOCID == FileID).Select(X =>
           new VideoUploaddetails()
           {
               DOCUMENTNAME = X.DOCUMENTNAME,


           }

               ).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<VideoUploaddetails> GetVideoUploaddetails()
        {
            try
            {
                //return dbEntities.TBL_GN_DIGITALDOC_DETAILS.Select(X =>

                // new VideoUploaddetails()
                // {
                //     DIGITALDOCTYPEID = X.DIGITALDOCTYPEID,
                //     DOCUMENTNAME = X.DOCUMENTNAME,
                //     SUBJECTID = X.SUBJECTID,

                // }

                //).ToList();
                return dbEntities.TBL_GN_DIGITALDOC_DETAILS.Select(X => new VideoUploaddetails() { DIGITALDOCTYPEID = X.DIGITALDOCTYPEID, DOCUMENTNAME = X.DOCUMENTNAME, DIGITALDOCID = X.DIGITALDOCID, VideoPath = X.VideoPath, CREATEDDATE = X.CREATEDDATE }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<VideoUploaddetails> GetVideoUploaddetails(VideoUploaddetails objvideoDetails)
        {
            try
            {
                return dbEntities.TBL_GN_DIGITALDOC_DETAILS.Select(X =>

                 new VideoUploaddetails()
                 {
                     DIGITALDOCTYPEID = X.DIGITALDOCTYPEID,
                     DOCUMENTNAME = X.DOCUMENTNAME,
                     SUBJECTID = X.SUBJECTID,

                 }

                ).ToList();
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
                List<CourseMaster> Coursedetails = new List<CourseMaster>();

                return dbEntities.TBL_MASTER_COURSE.Select(X => new CourseMaster() { NAME = X.NAME, ID = X.COURSEID }).ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<SubjectMaster> Getsubject()
        {
            try
            {
                List<SubjectMaster> Subjectdetails = new List<SubjectMaster>();

                return dbEntities.TBL_MASTER_SUBJECT.Select(X => new SubjectMaster() { SUBJECTNAME = X.NAME, SUBJECTID = X.SUBJECTID }).ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        // Added by Pramod for API

        public List<VideoUploaddetails> GetVideoUploaddetailsBySubjectId(int? subjectId)
        {
            try
            {

                return dbEntities.USP_GET_VideosBySubject(subjectId).Select(X =>
                 new VideoUploaddetails()
                 {
                     DIGITALDOCTYPEID = X.DIGITALDOCTYPEID,
                     DOCUMENTNAME = X.DOCUMENTNAME,
                     DIGITALDOCID = X.DIGITALDOCID,
                     VideoPath = X.VideoPath,
                     CREATEDDATE = X.CREATEDDATE,
                     SUBJECTID = X.SUBJECTID,
                     SubjectName = X.SubjectName,
                     CourseName = X.CourseName
                 }).ToList();
                //return dbEntities.TBL_GN_DIGITALDOC_DETAILS.Where(x => x.SUBJECTID == subjectId).Select(X =>
                //    new VideoUploaddetails()
                //    {
                //        DIGITALDOCTYPEID = X.DIGITALDOCTYPEID,
                //        DOCUMENTNAME = X.DOCUMENTNAME,
                //        DIGITALDOCID = X.DIGITALDOCID,
                //        VideoPath = X.VideoPath,
                //        CREATEDDATE = X.CREATEDDATE
                //    }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<RecommendedVideoModel> GET_RecommendedVideos(int? StudentId)
        {
            try
            {
                //  List<VideoUploaddetails> obj = new List<VideoUploaddetails>();
                // return obj;
                var videos = dbEntities.USP_GET_RecommendedVideos(StudentId).Select(X =>
                 new VideoUploaddetails()
                 {
                     DIGITALDOCTYPEID = X.DIGITALDOCTYPEID,
                     DOCUMENTNAME = X.DOCUMENTNAME,
                     DIGITALDOCID = X.DIGITALDOCID,
                     VideoPath = X.VideoPath,
                     CREATEDDATE = X.CREATEDDATE,
                     SUBJECTID = X.SUBJECTID,
                     SubjectName = X.SubjectName,
                     CourseName = X.CourseName
                 }).ToList();

                List<RecommendedVideoModel> lstModel = new List<RecommendedVideoModel>();

                lstModel = (from a in videos
                            select new RecommendedVideoModel
                            {
                                Subject = a.SubjectName,
                                SubjectId = a.SUBJECTID,
                                lstVideoModel = videos.Where(t => t.SUBJECTID == a.SUBJECTID).ToList()
                            }).ToList();


                return lstModel;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PopularVideoModel> GET_PopularVideos(int? StudentId)
        {
            try
            {
                //  List<VideoUploaddetails> obj = new List<VideoUploaddetails>();
                // return obj;
                var videos = dbEntities.USP_GET_PopularVideos(StudentId).Select(X =>
                 new VideoUploaddetails()
                 {
                     DIGITALDOCTYPEID = X.DIGITALDOCTYPEID,
                     DOCUMENTNAME = X.DOCUMENTNAME,
                     DIGITALDOCID = X.DIGITALDOCID,
                     VideoPath = X.VideoPath,
                     CREATEDDATE = X.CREATEDDATE,
                     SUBJECTID = X.SUBJECTID,
                     SubjectName = X.SubjectName,
                     CourseName = X.CourseName
                 }).ToList();

                List<PopularVideoModel> lstModel = new List<PopularVideoModel>();

                lstModel = (from a in videos
                            select new PopularVideoModel
                            {
                                Subject = a.SubjectName,
                                SubjectId = a.SUBJECTID,
                                lstVideoModel = videos.Where(t => t.SUBJECTID == a.SUBJECTID).ToList()
                            }).ToList();


                return lstModel;

            }
            catch (Exception)
            {

                throw;
            }
        }


        public VideoDetailsViewModel GET_VideoDetails(long VideoId)
        {
            try
            {
                var videos = dbEntities.USP_GET_VideoDetails(VideoId).Select(X =>
                 new VideoDetailsViewModel()
                 {
                     DIGITALDOCTYPEID = X.DIGITALDOCTYPEID,
                     DOCUMENTNAME = X.DOCUMENTNAME,
                     DIGITALDOCID = X.DIGITALDOCID,
                     VideoPath = X.VideoPath,
                     CREATEDDATE = X.CREATEDDATE,
                     SUBJECTID = X.SUBJECTID,
                     ALLOWANONYMOUS = X.ALLOWANONYMOUS,
                     CourseId = X.CourseId,
                     CREATEDBY = X.CREATEDBY,
                     DOWNLOADCOUNT = X.DOWNLOADCOUNT,
                     RefDocs = X.RefDocs,
                     VideoDesc = X.VideoDesc,
                     VIEWCOUNT = X.VIEWCOUNT


                 }).FirstOrDefault();

                return videos;

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
