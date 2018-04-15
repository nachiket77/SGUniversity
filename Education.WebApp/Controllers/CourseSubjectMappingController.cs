using Education.Core.SubjectCourseMapping;
using Education.Entity.SubjectCourseMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.WebApp.Controllers
{
    public class CourseSubjectMappingController : Controller
    {
        ISubjectCourseMapping _SubjectCourseMapping;
        //ICourse _ICourseDetailsRepository;

        public CourseSubjectMappingController(ISubjectCourseMapping repos)
        {
            this._SubjectCourseMapping = repos;
            // this._ICourseDetailsRepository = course;
        }
        // GET: CourseSubjectMapping
        public ActionResult Index()
        {
            AllSubjectCourseMappingDetails objalldetails = new AllSubjectCourseMappingDetails();
            objalldetails.CourseList = _SubjectCourseMapping.GetCourse();
            objalldetails.SubjectList = _SubjectCourseMapping.Getsubject();

            return View(objalldetails);
        }

        [HttpPost]
        public ActionResult Index(AllSubjectCourseMappingDetails allsubejctcoursemappingdetails, string chk, bool checkResp = false)
        {
            try
            {
              bool result=  _SubjectCourseMapping.CreateSubjectCourseMappingDetails(allsubejctcoursemappingdetails);
                AllSubjectCourseMappingDetails det = new AllSubjectCourseMappingDetails();
                det.CourseList = _SubjectCourseMapping.GetCourse();
                det.SubjectList = _SubjectCourseMapping.Getsubject();
                if (result==true)
                {
                    // RedirectToAction("AddStudent", objalldetails.StudentDetails.USERID);
                    //ViewBag.message = "Success";
                    TempData["Success"] = "Maping Details Added Successfully!";
                    
                }
                else
                {

                    TempData["Error"] = "Unbale to add Details. Please try after some times or contact to tech team!";
                }
                ModelState.Clear();
                return View("Index", "_Layout", det);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // GET: CourseSubjectMapping/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CourseSubjectMapping/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseSubjectMapping/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseSubjectMapping/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CourseSubjectMapping/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseSubjectMapping/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CourseSubjectMapping/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
