using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Education.Entity.Validators;

namespace Education.Entity.Admin
{
  public class VideoUploaddetails
    {
        public long DIGITALDOCID { get; set; }
        public Nullable<int> DIGITALDOCTYPEID { get; set; }
        public string DOCUMENTNAME { get; set; }
        
        public Nullable<int> SUBJECTID { get; set; }

        public int CourseId { get; set; }
        
        public Nullable<long> CREATEDBY { get; set; }
        public Nullable<System.DateTime> CREATEDDATE { get; set; }
        public Nullable<long> MODIFIEDBY { get; set; }
        public Nullable<System.DateTime> MODIFIEDDATE { get; set; }
        public Nullable<bool> STATUS { get; set; }
        public Nullable<bool> ALLOWANONYMOUS { get; set; }
        public Nullable<int> DOWNLOADCOUNT { get; set; }
        public Nullable<int> VIEWCOUNT { get; set; }

        [MaximumFileSizeValidator(1024.0)]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.3gpp|.m4v|.mp4|.mpeg|.ogg|.quicktime|.webm|.x-ms-wmv)$", ErrorMessage ="Please select valid file")]
        //[Required(ErrorMessage ="Please choose file"),FileExtensions(ErrorMessage = "Please select validd file", Extensions = "3gpp,m4v,mp4,mpeg,ogg,quicktime,webm,x-ms-wmv")]
        //[RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.mp4)$", ErrorMessage = "Only Image files allowed.")]
        [Required(ErrorMessage = "Please choose file")]
        public HttpPostedFileBase file { get; set; }
        public string VideoPath { get; set; }
        
        public string SubjectName { get; set; }
        public string CourseName { get; set; }

        public string VideoDesc { get; set; }

        [MaximumFileSizeValidator(2.0)]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.doc|.docs|.pdf|.txt)$", ErrorMessage = "Please select valid file")]
        public HttpPostedFileBase RefDocument { get; set; }

        public string RefDocumentPath { get; set; }

    }

    public class CourseMaster
    {
        public string NAME
        {
            get;
            set;
        }


        [Required(ErrorMessage = "Please select Course")]
        public int ID
        {
            get;
            set;
        }

        public List<CourseMaster> Coursedetails
        {
            get;
            set;
        }

       
    }

    public class SubjectMaster
    {
        public string SUBJECTNAME
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Please select Subject")]
        public int SUBJECTID
        {
            get;
            set;
        }

        public List<SubjectMaster> Subjectdetails
        {
            get;
            set;
        }

      
    }

    public class Student
    {
        public Nullable<int> StudentId { get; set; }
    }

    public class RecommendedVideoModel
    {
        public string Subject { get; set; }
        public Nullable<int> SubjectId { get; set; }
        public List<VideoUploaddetails> lstVideoModel { get; set; }
    }

    public class PopularVideoModel
    {
        public string Subject { get; set; }
        public Nullable<int> SubjectId { get; set; }
        public List<VideoUploaddetails> lstVideoModel { get; set; }
    }

    public class VideoDetailsViewModel
    {
        public long? DIGITALDOCID { get; set; }
        public int? DIGITALDOCTYPEID { get; set; }
        public string DOCUMENTNAME { get; set; }
        public Nullable<int> SUBJECTID { get; set; }
        public Nullable<long> CREATEDBY { get; set; }
        public Nullable<DateTime> CREATEDDATE { get; set; }
        public Nullable<long> MODIFIEDBY { get; set; }
        public Nullable<DateTime> MODIFIEDDATE { get; set; }
        public Nullable<bool> STATUS { get; set; }
        public Nullable<bool> ALLOWANONYMOUS { get; set; }
        public Nullable<int> DOWNLOADCOUNT { get; set; }
        public Nullable<int> VIEWCOUNT { get; set; }
        public string VideoPath { get; set; }
        public Nullable<int> CourseId { get; set; }
        public string VideoDesc { get; set; }
        public string RefDocs { get; set; }
    }

    public class Video
    {
        public long VideoId { get; set; }
    }
}
