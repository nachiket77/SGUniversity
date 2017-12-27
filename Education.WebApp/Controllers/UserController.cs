using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Education.Core;

namespace Education.WebApp.Controllers
{
    public class UserController : Controller
    {
        public IUserReposetory _UserReporsetory;
        public UserController(IUserReposetory _repo)
        {
            _UserReporsetory = _repo;
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult Insert()
        {
            _UserReporsetory.InsertUserType("admin");
            return View();

        }
    }
}