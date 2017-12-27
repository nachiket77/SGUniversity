using Education.Core.Students;
using Education.Entity.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

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
        public ActionResult Index(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No)
        {

            //RedirectToAction("ListStudent");
            //return View();
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

            AllDetails Details = new AllDetails();
            Details.StudentList = _StudentReposetory.GetStudentDetails();
            var students = from stu in Details.StudentList select stu;
            {
                students = students.Where(stu => stu.FIRSTNAME.ToUpper().Contains(Search_Data.ToUpper()) || stu.LASTNAME.ToUpper().Contains(Search_Data.ToUpper())).ToList();
            }
            Details.StudentList.AddRange(students);
            Details.StudentList = students.ToList();
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
            int Size_Of_Page = 4;
            int No_Of_Page = (Page_No ?? 1);
            return View(Details.StudentList.ToPagedList(No_Of_Page, Size_Of_Page));
        }

        public ActionResult ListStudent( string Search_Data, string Filter_Value, int? Page_No)
        {
            //RedirectToAction("ListStudent");
            //return View();
            //ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Name_Description" : "";
            //ViewBag.SortingDate = Sorting_Order == "Date_Enroll" ? "Date_Description" : "Date";
            //ViewBag.SortingUserID = String.IsNullOrEmpty(Sorting_Order) ? "UserID" : "";

            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }

            ViewBag.FilterValue = Search_Data;

            List<StudentDetails> Details = new List<StudentDetails>();
            Details = _StudentReposetory.GetStudentDetails();
            var students = from stu in Details select stu;
            {
                if (Search_Data!=null)
                {
                    students = students.Where(stu => stu.FIRSTNAME.ToUpper().Contains(Search_Data.ToUpper()) || stu.LASTNAME.ToUpper().Contains(Search_Data.ToUpper())).ToList();
                }
                
            }
            //Details.StudentList.AddRange(students);
            Details = students.ToList();
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

        [HttpPost]
        public ActionResult ListStudent(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No)
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

            AllDetails Details = new AllDetails();
            Details.StudentList = _StudentReposetory.GetStudentDetails();
            var students = from stu in Details.StudentList select stu;
            {
                if (Search_Data != null)
                {
                    students = students.Where(stu => stu.FIRSTNAME.ToUpper().Contains(Search_Data.ToUpper()) || stu.LASTNAME.ToUpper().Contains(Search_Data.ToUpper())).ToList();
                }
            }
            Details.StudentList.AddRange(students);
            Details.StudentList=students.ToList();
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
            return View(Details.StudentList.ToPagedList(No_Of_Page, Size_Of_Page));
        }

        [HttpPost]
        public ActionResult UpdateStudentDetails(int userid, string FirstName, string Last, string middle, string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No)
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

                _StudentReposetory.updateStudentDetail(userid, FirstName, Last, middle);
                AllDetails Details = new AllDetails();
                Details.StudentList = _StudentReposetory.GetStudentDetails();
                TempData["Success"] = "Details Updated Successfully!";
                int Size_Of_Page = 10;
                int No_Of_Page = (Page_No ?? 1);
                return View("ListStudent", "_Layout", Details.StudentList.ToPagedList(No_Of_Page, Size_Of_Page));

            }
            catch (Exception)
            {

                throw;
            }
            //  string USERID = Convert.ToString(studentdetails.USERID);


        }

    }
}