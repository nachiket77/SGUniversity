using Education.DB;
using Education.Entity.Master;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Education.Core.Students;
using Education.Core.Admin.Master;
using Education.Entity.Students;
using System.Threading.Tasks;

namespace Education.WebApp.Controllers.API
{
    [RoutePrefix("api/Course")]
    public class CourseController : ApiController
    {
        public ajay_dbEntities dbajay_dbEntities = new ajay_dbEntities();
        // IStudentReposetory _StudentReposetory;
        ICourse _ICourseDetailsRepository;
        public IStudentReposetory _StudentReposetory = null;    
        public CourseController()
        {
            this._StudentReposetory = new StudentReposetory();
        }

        public CourseController(IStudentReposetory repos, ICourse course)
        {

            this._StudentReposetory = repos;
            this._StudentReposetory = new StudentReposetory();
            this._ICourseDetailsRepository = course;
        }


        [HttpGet]
        [Route("GetCourse")]
        public AllDetails GetCourse()
        {
            AllDetails objalldetails = new AllDetails();

            try
            {
                //objalldetails.CourseList = objall.CourseList;
                //Subjectdetails =dbajay_dbEntities.TBL_MASTER_COURSE.Select(X => new CourseMaster() { NAME = X.NAME }).ToList();

                Dictionary<string, string> dict = new Dictionary<string, string>();


                //objalldetails.CourseList= _StudentReposetory.GetCourse();
                objalldetails.CourseList = _StudentReposetory.GetCourse();

                return objalldetails;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
