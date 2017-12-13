using Education.Core.Admin.Master;
using Education.Core.Students;
using Education.Entity.Master;
using Education.Entity.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Education.WebApp.Controllers
{
    public class StudentController : Controller
    {
        IStudentReposetory _StudentReposetory;
        ICourse _ICourseDetailsRepository;

        public StudentController(IStudentReposetory repos, ICourse course)
        {
            this._StudentReposetory = repos;
            this._ICourseDetailsRepository = course;
        }
        // GET: Student
        public ActionResult Index()
        {
            AllDetails objalldetails = new AllDetails();
            objalldetails.CourseList = _StudentReposetory.GetCourse();
            objalldetails.BoardsList = _StudentReposetory.GetBoards();
            objalldetails.ClassesList = _StudentReposetory.GetClasses();
            return View(objalldetails);
        }

        public ActionResult AddStudent()
        {
            AllDetails objalldetails = new AllDetails();
            objalldetails.CourseList = _StudentReposetory.GetCourse();
            objalldetails.BoardsList = _StudentReposetory.GetBoards();
            objalldetails.ClassesList = _StudentReposetory.GetClasses();
            return View(objalldetails);
        }
        [HttpPost]
        public ActionResult AddStudentDetails(AllDetails allDetails, string chk, bool checkResp = false)
        {
            var selectedCourseID = allDetails.CourseList.Where(c => c.IsChecked).Select(c => c.ID);

            AllDetails objalldetails = new AllDetails();
            CheckBoxList ChkItems = new CheckBoxList();
            objalldetails.StudentDetails = allDetails.StudentDetails;
            try
            {

                objalldetails.StudentDetails.AddressLine1 = objalldetails.StudentDetails.AddressLine1;
                objalldetails.StudentDetails.AddressLine2 = objalldetails.StudentDetails.AddressLine2;
                objalldetails.StudentDetails.AddressTypeID = objalldetails.StudentDetails.AddressTypeID;
                objalldetails.StudentDetails.CityID = objalldetails.StudentDetails.CityID;
                objalldetails.StudentDetails.CountryID = objalldetails.StudentDetails.CountryID;

                objalldetails.StudentDetails.CREATEDBY = Convert.ToInt64(Session["UserID"]);
                objalldetails.StudentDetails.DOB = objalldetails.StudentDetails.DOB;
                objalldetails.StudentDetails.EMAILID = objalldetails.StudentDetails.EMAILID;
                objalldetails.StudentDetails.FIRSTNAME = objalldetails.StudentDetails.FIRSTNAME;
                objalldetails.StudentDetails.Gender = objalldetails.StudentDetails.Gender;
                //_studentDetails.Gender = studentDetail.Gender.ToLower() == "male" ? Entity.Master.Gender.Male : Entity.Master.Gender.Female;
                objalldetails.StudentDetails.LASTNAME = objalldetails.StudentDetails.LASTNAME;
                objalldetails.StudentDetails.MIDDLENAME = objalldetails.StudentDetails.MIDDLENAME;
                objalldetails.StudentDetails.MOBILENO = objalldetails.StudentDetails.MOBILENO;
                objalldetails.StudentDetails.NATIONALITY = objalldetails.StudentDetails.NATIONALITY;
                objalldetails.StudentDetails.Pincode = objalldetails.StudentDetails.Pincode;
                objalldetails.StudentDetails.StateID = objalldetails.StudentDetails.StateID;
                objalldetails.StudentDetails.UserType = Entity.Master.UserType.Student;
                objalldetails.StudentDetails.PASSWORD = GeneratePassword(objalldetails.StudentDetails.MOBILENO);
                objalldetails.StudentDetails.STATUSID = Convert.ToInt16(Entity.Master.UserLoginStatus.Active);
                objalldetails.StudentDetails.CourseList = allDetails.CourseList;
                objalldetails.StudentDetails.CourseName = objalldetails.StudentDetails.CourseName;
                objalldetails.ClassesMaster = allDetails.ClassesMaster;
                objalldetails.StudentDetails.INSTITUTIONNAME = allDetails.StudentDetails.INSTITUTIONNAME;
                objalldetails.StudentDetails.PASSINGYEAR = allDetails.StudentDetails.PASSINGYEAR;
                objalldetails.BoardsMaster = allDetails.BoardsMaster;
                bool Result = _StudentReposetory.StudentExist(allDetails.StudentDetails);
                if (!Result)
                {
                    objalldetails.StudentDetails.PASSWORD = GeneratePassword("nghbj");
                    objalldetails = _StudentReposetory.CreateStudent(allDetails);
                    Session["USERID"] = objalldetails.StudentDetails.USERID;
                    if (objalldetails.StudentDetails.USERID > 0)
                    {
                        // RedirectToAction("AddStudent", objalldetails.StudentDetails.USERID);
                        ViewBag.message = "Success";
                        RedirectToAction("Index", "Student");
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
                AllDetails det = new AllDetails();
                det.CourseList = _StudentReposetory.GetCourse();
                det.BoardsList = _StudentReposetory.GetBoards();
                det.ClassesList = _StudentReposetory.GetClasses();
                ModelState.Clear();
                return View("AddStudent", "_Layout", det);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public ActionResult AddParentDetails(AllDetails allDetails)
        {
            AllDetails objalldetails = new AllDetails();
            objalldetails.ParentDetails = allDetails.ParentDetails;
            try
            {

                objalldetails.ParentDetails.FATHERNAME = objalldetails.ParentDetails.FATHERNAME;
                objalldetails.ParentDetails.FATHEREMAIL = objalldetails.ParentDetails.FATHEREMAIL;
                objalldetails.ParentDetails.FATHERMOBILENUMBER = objalldetails.ParentDetails.FATHERMOBILENUMBER;
                objalldetails.ParentDetails.FATHERCOMPANYNAME = objalldetails.ParentDetails.FATHERCOMPANYNAME;
                objalldetails.ParentDetails.FATHERDESIGNATION = objalldetails.ParentDetails.FATHERDESIGNATION;
                objalldetails.ParentDetails.FATHEROCCUPATION = objalldetails.ParentDetails.FATHEROCCUPATION;

                objalldetails.ParentDetails.MOTHERCOMPANYNAME = objalldetails.ParentDetails.MOTHERCOMPANYNAME;
                objalldetails.ParentDetails.MOTHERDESIGNATION = objalldetails.ParentDetails.MOTHERDESIGNATION;
                //  objalldetails.ParentDetails.MOTHEREMAIL = objalldetails.ParentDetails.MOTHEREMAIL;
                objalldetails.ParentDetails.MOTHERMOBILENUMBER = objalldetails.ParentDetails.MOTHERMOBILENUMBER;
                objalldetails.ParentDetails.MOTHERNAME = objalldetails.ParentDetails.MOTHERNAME;
                objalldetails.ParentDetails.MOTHEROCCUPATION = objalldetails.ParentDetails.MOTHEROCCUPATION;

                //bool Result = _StudentReposetory.StudentExist(allDetails.StudentDetails);
                //if (!Result)
                //{
                if (Session["USERID"] != null)
                {
                    allDetails.ParentDetails.USERID = Convert.ToInt16(Session["USERID"]);

                }
                objalldetails = _StudentReposetory.CreateParentDetails(allDetails);
                if (objalldetails.StudentDetails.USERID > 0)
                {
                    // RedirectToAction("AddInstitute", objalldetails.StudentDetails.USERID);
                    ViewBag.message = "Success";
                    return View("AddStudent");
                }
                else
                {
                    ModelState.AddModelError("EMAILID", "Unbale to add Student. Please try after some times or contact to tech team");

                }

                // }
                //else
                //{
                //    ModelState.AddModelError("EMAILID", "Email number already Registered");
                //    ModelState.AddModelError("MOBILENO", "Mobile number already Registered");
                //}


                // }

                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult AddProfessionalDetails(AllDetails allDetails)
        {
            AllDetails objalldetails = new AllDetails();
            objalldetails.ProfessionalDetails = allDetails.ProfessionalDetails;
            try
            {

                objalldetails.ProfessionalDetails.COMPANYNAME = objalldetails.ProfessionalDetails.COMPANYNAME;
                objalldetails.ProfessionalDetails.DESIGNATION = objalldetails.ProfessionalDetails.DESIGNATION;
                objalldetails.ProfessionalDetails.EMPLOYEETYPE = objalldetails.ProfessionalDetails.EMPLOYEETYPE;
                objalldetails.ProfessionalDetails.REMARKS = objalldetails.ProfessionalDetails.REMARKS;



                //bool Result = _StudentReposetory.StudentExist(allDetails.StudentDetails);
                //if (!Result)
                //{
                if (Session["USERID"] != null)
                {
                    allDetails.ProfessionalDetails.USERID = Convert.ToInt16(Session["USERID"]);
                }

                objalldetails = _StudentReposetory.CreateProfessionalDetails(allDetails);
                if (objalldetails.ProfessionalDetails.USERID > 0)
                {
                    // RedirectToAction("AddInstitute", objalldetails.StudentDetails.USERID);
                    ViewBag.message = "Success";
                    return View("AddStudent");
                }
                else
                {
                    ModelState.AddModelError("EMAILID", "Unbale to add Student. Please try after some times or contact to tech team");

                }

                // }
                //else
                //{
                //    ModelState.AddModelError("EMAILID", "Email number already Registered");
                //    ModelState.AddModelError("MOBILENO", "Mobile number already Registered");
                //}


                // }

                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult ListStudent()
        {
            AllDetails StudentDetails = new AllDetails();
            StudentDetails.StudentList = _StudentReposetory.GetStudentDetails();

            return View();
        }



        string GeneratePassword(string Key)
        {
            Random generator = new Random();
            Key = generator.Next(0, 1000000).ToString("D6");
            return Key;
        }
    }
}