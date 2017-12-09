using Education.Core.Teacher;
using Education.Entity.Teachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.WebApp.Controllers
{
    public class TeacherController : Controller
    {
        ITeacherRepository _TeacherReposetory;
        //ICourse _ICourseDetailsRepository;

        public TeacherController(ITeacherRepository repos )
        {
            this._TeacherReposetory = repos;
           // this._ICourseDetailsRepository = course;
        }
        // GET: Videos
        public ActionResult Index()
        {
            AllTeacherDetails objalldetails = new AllTeacherDetails();
            objalldetails.CourseList = _TeacherReposetory.GetCourse();
            objalldetails.SubjectList = _TeacherReposetory.Getsubject();

            return View(objalldetails);
        }

        public ActionResult AddTeacher()
        {
            AllTeacherDetails objalldetails = new AllTeacherDetails();
            objalldetails.CourseList = _TeacherReposetory.GetCourse();
            objalldetails.SubjectList = _TeacherReposetory.Getsubject();

            return View(objalldetails);
        }
        [HttpPost]
        public ActionResult AddTeacherDetails(AllTeacherDetails allteacherDetails, string chk, bool checkResp = false)
        {
            var selectedCourseID = allteacherDetails.CourseList.Where(c => c.IsChecked).Select(c => c.ID);

            AllTeacherDetails objallteacherdetails = new AllTeacherDetails();

            objallteacherdetails.teacherdetails = allteacherDetails.teacherdetails;
            try
            {

                objallteacherdetails.teacherdetails.COURSEID = objallteacherdetails.teacherdetails.COURSEID;
                objallteacherdetails.teacherdetails.CREATEDBY = objallteacherdetails.teacherdetails.CREATEDBY;
                objallteacherdetails.teacherdetails.CREATEDDATE = objallteacherdetails.teacherdetails.CREATEDDATE;
                objallteacherdetails.teacherdetails.EMAILID = objallteacherdetails.teacherdetails.EMAILID;
                objallteacherdetails.teacherdetails.FIRSTNAME = objallteacherdetails.teacherdetails.FIRSTNAME;
                objallteacherdetails.teacherdetails.LASTNAME = objallteacherdetails.teacherdetails.LASTNAME;
                objallteacherdetails.teacherdetails.MIDDLENAME = objallteacherdetails.teacherdetails.MIDDLENAME;
                objallteacherdetails.teacherdetails.MOBILENUMBER = objallteacherdetails.teacherdetails.MOBILENUMBER;
                objallteacherdetails.teacherdetails.SUBJECTID = objallteacherdetails.teacherdetails.SUBJECTID;


                bool Result = _TeacherReposetory.TeacherExist(objallteacherdetails.teacherdetails);
                if (!Result)
                {
                    objallteacherdetails.teacherdetails.PASSWORD = GeneratePassword("asdhad");
                    objallteacherdetails = _TeacherReposetory.CreateTeacher(allteacherDetails);
                    Session["USERID"] = objallteacherdetails.teacherdetails.TEACHERID;
                    if (objallteacherdetails.teacherdetails.TEACHERID > 0)
                    {
                        // RedirectToAction("AddStudent", objalldetails.StudentDetails.USERID);
                        ViewBag.message = "Success";
                        RedirectToAction("Index", "Teacher");
                    }
                    else
                    {
                        ModelState.AddModelError("EMAILID", "Unbale to add Student. Please try after some times or contact to tech team");

                    }

                }
                else
                {
                    ModelState.AddModelError("EMAILID", "Email number already Registered");
                    ModelState.AddModelError("MOBILENO", "Mobile number already Registered");
                }


                // }

                // }
                AllTeacherDetails det = new AllTeacherDetails();
                det.CourseList = _TeacherReposetory.GetCourse();
                det.SubjectList = _TeacherReposetory.Getsubject();
                
                ModelState.Clear();
                return View("AddTeacher", "_Layout", det);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult ListTeacher()
        {
            AllTeacherDetails Details = new AllTeacherDetails();
            Details.allteacherdetails = _TeacherReposetory.GetteacherDetails();
            return View(Details);
        }

        string GeneratePassword(string Key)
        {
            Random generator = new Random();
            Key = generator.Next(0, 1000000).ToString("D6");
            return Key;
        }

        [HttpPost]
        public ActionResult UpdateTeacherDetails(int userid, string FirstName, string Last, string middle)
        {
            try
            {

                _TeacherReposetory.updateteacherDetail(userid, FirstName, Last, middle);
                AllTeacherDetails Details = new AllTeacherDetails();
                Details.allteacherdetails = _TeacherReposetory.GetteacherDetails();
                ViewBag.message = "Record Updated Successfully";
                return View("ListTeacher", "_Layout", Details);

            }
            catch (Exception)
            {

                throw;
            }
            //  string USERID = Convert.ToString(studentdetails.USERID);


        }

    }
}