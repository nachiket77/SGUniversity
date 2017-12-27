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
        public AllVideosDetails CreateVideoDetails(AllVideosDetails objvideoDetails)
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

                dbEntities.TBL_GN_DIGITALDOC_DETAILS.Add(videodetails);
                dbEntities.SaveChanges();
                return objvideoDetails;
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
    }
}
