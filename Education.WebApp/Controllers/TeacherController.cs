using Education.Core.Teacher;
using Education.Entity.Teachers;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

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
                        TempData["Success"] = "Teachers Details Added Successfully!" +" "+ "TeacherID:" +" "+ Session["USERID"];
                        RedirectToAction("Index", "Teacher");
                    }
                    else
                    {
                        //ModelState.AddModelError("EMAILID", "Unbale to add Student. Please try after some times or contact to tech team");
                        TempData["Error"] = "Unbale to add Teacher. Please try after some times or contact to tech team!";

                    }

                }
                else
                {
                    //ModelState.AddModelError("EMAILID", "Email number already Registered");
                    //ModelState.AddModelError("MOBILENO", "Mobile number already Registered");
                    TempData["Error"] = "Mobile number already Registered!";
                }


                // }

                // }
                AllTeacherDetails det = new AllTeacherDetails();
                det.CourseList = _TeacherReposetory.GetCourse();
                det.SubjectList = _TeacherReposetory.Getsubject();
                
                //ModelState.Clear();
                return View("AddTeacher", "_Layout", det);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult ListTeacher(string Search_Data, string Filter_Value, int? Page_No)
        {
            
            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }

            ViewBag.FilterValue = Search_Data;

            List<TeacherDetails> Details = new List<TeacherDetails>();
            Details = _TeacherReposetory.GetteacherDetails();
            var teachers = from stu in Details select stu;
            {
                if (Search_Data!=null)
                {
                    teachers = teachers.Where(stu => stu.FIRSTNAME.ToUpper().Contains(Search_Data.ToUpper()) || stu.LASTNAME.ToUpper().Contains(Search_Data.ToUpper())).ToList();
                }
                
            }
            //Details.StudentList.AddRange(students);
            Details = teachers.ToList();
        
            int Size_Of_Page = 10;
            int No_Of_Page = (Page_No ?? 1);
            return View(Details.ToPagedList(No_Of_Page, Size_Of_Page));


            //AllTeacherDetails Details = new AllTeacherDetails();
            //Details.allteacherdetails = _TeacherReposetory.GetteacherDetails();
            //return View(Details);
        }

        [HttpPost]
        public ActionResult ListTeacher(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No)
        {
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Name_Description" : "";
            ViewBag.SortingDate = Sorting_Order == "Date_Enroll" ? "Date_Description" : "Date";
            ViewBag.SortingUserID = String.IsNullOrEmpty(Sorting_Order) ? "UserID" : "";

            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }

            ViewBag.FilterValue = Search_Data;

            List<TeacherDetails> Details = new List<TeacherDetails>();
            Details = _TeacherReposetory.GetteacherDetails();
            var teachers = from stu in Details select stu;
            {
                if (Search_Data != null)
                {
                    teachers = teachers.Where(stu => stu.FIRSTNAME.ToUpper().Contains(Search_Data.ToUpper()) || stu.LASTNAME.ToUpper().Contains(Search_Data.ToUpper())).ToList();
                }
            }
            Details.AddRange(teachers);
            Details = teachers.ToList();
            //switch (Sorting_Order)
            //{
            //    case "Name_Description":
            //        Details.StudentList.OrderByDescending(stu => stu.FIRSTNAME);
            //        break;
            //    case "Date":
            //        Details.StudentList.OrderBy(stu => stu.DOB);
            //        break;
            //    case "UserID":
            //        Details.StudentList.OrderBy(stu => stu.USERID);
            //        break;
            //    default:
            //        Details.StudentList.OrderByDescending(stu => stu.FIRSTNAME);
            //        break;
            //}
            int Size_Of_Page = 10;
            int No_Of_Page = (Page_No ?? 1);
            return View(Details.ToPagedList(No_Of_Page, Size_Of_Page));
        }

        string GeneratePassword(string Key)
        {
            Random generator = new Random();
            Key = generator.Next(0, 1000000).ToString("D6");
            return Key;
        }

        [HttpPost]
        public ActionResult UpdateTeacherDetails(int userid, string FirstName, string Last, string middle, string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No)
        {
            try
            {
                ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Name_Description" : "";
                ViewBag.SortingDate = Sorting_Order == "Date_Enroll" ? "Date_Description" : "Date";
                ViewBag.SortingUserID = String.IsNullOrEmpty(Sorting_Order) ? "UserID" : "";

                if (Search_Data != null)
                {
                    Page_No = 1;
                }
                else
                {
                    Search_Data = Filter_Value;
                }

                ViewBag.FilterValue = Search_Data;

                _TeacherReposetory.updateteacherDetail(userid, FirstName, Last, middle);
                AllTeacherDetails Details = new AllTeacherDetails();
                Details.allteacherdetails = _TeacherReposetory.GetteacherDetails();
                TempData["Success"] = "Details Updated Successfully!";
                int Size_Of_Page = 10;
                int No_Of_Page = (Page_No ?? 1);
                return View("ListTeacher", "_Layout", Details.allteacherdetails.ToPagedList(No_Of_Page, Size_Of_Page));

            }
            catch (Exception)
            {

                throw;
            }
            //  string USERID = Convert.ToString(studentdetails.USERID);


        }

    }
}