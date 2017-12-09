using Education.Core.Students;
using Education.Entity.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.WebApp.Controllers
{
    public class ListController : Controller
    {
        IStudentReposetory _StudentReposetory;
        public ListController(IStudentReposetory repos)
        {
            this._StudentReposetory = repos;
        }
        // GET: List
        public ActionResult Index()
        {
            RedirectToAction("ListStudent");
            return View();
        }

        public ActionResult ListStudent()
        {

            AllDetails Details = new AllDetails();
            Details.StudentList = _StudentReposetory.GetStudentDetails();
            return View(Details);
        }

        [HttpPost]
        public ActionResult UpdateStudentDetails(int userid, string FirstName, string Last, string middle)
        {
            try
            {

                _StudentReposetory.updateStudentDetail(userid, FirstName, Last, middle);
                AllDetails Details = new AllDetails();
                Details.StudentList = _StudentReposetory.GetStudentDetails();
                ViewBag.message = "Record Updated Successfully";
                return View("ListStudent", "_Layout", Details);

            }
            catch (Exception)
            {

                throw;
            }
            //  string USERID = Convert.ToString(studentdetails.USERID);


        }

    }
}