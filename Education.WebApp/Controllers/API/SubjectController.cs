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
using Education.Core.Admin;
using System.Web.UI.WebControls;

namespace Education.WebApp.Controllers.API
{
    [RoutePrefix("api/Subject")]
    public class SubjectController : ApiController
    {
        public ajay_dbEntities dbajay_dbEntities = new ajay_dbEntities();
        // IStudentReposetory _StudentReposetory;
        ICourse _ICourseDetailsRepository;
        public IStudentReposetory _StudentDetailsRepository = null;
        public SubjectController()
        {
            this._StudentDetailsRepository = new StudentReposetory();
        }

        public SubjectController(IStudentReposetory repos, ICourse course)
        {

            this._StudentDetailsRepository = repos;
            this._StudentDetailsRepository = new StudentReposetory();
            this._ICourseDetailsRepository = course;
        }

        [HttpGet]
        [Route("GetSubject")]
        public AllDetails GetSubject(AllDetails obj)
        {
            AllDetails objalldetails = new AllDetails();

            try
            {

                Dictionary<string, string> dict = new Dictionary<string, string>();
                objalldetails.subjectList = _StudentDetailsRepository.Getsubject();

                return objalldetails;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
