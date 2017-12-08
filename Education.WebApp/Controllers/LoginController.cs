using Education.Core;
using Education.Entity.Login;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace Education.WebApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public IUserReposetory _UserReporsetory;

        public LoginController()
        {
            // _UserReporsetory = _repo;
        }
        public LoginController(IUserReposetory _repo)
        {
            _UserReporsetory = _repo;
        }


        public ActionResult Login()
        {
            LoginView loginView = new LoginView();
            loginView.UserTypeList = _UserReporsetory.GetUserType().Select(X => new SelectListItem() { Value = X.UsetTypeId.ToString(), Text = X.UsetType });


            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginView loginView)
        {
            if (ModelState.IsValid)
            {
                Education.Entity.Login.Login login = new Entity.Login.Login();
                login.LoginID = loginView.LoginID;
                login.Password = loginView.Password;
                login.UserTypeID = loginView.UserTypeID;

                LoginResponse loginResponse = _UserReporsetory.Login(login);

                if (loginResponse.ErrorMessage == "")
                {

                }
                else
                {
                    loginView.ErrorMessage = loginResponse.ErrorMessage;


                }



            }
            loginView.UserTypeList = _UserReporsetory.GetUserType().Select(X => new SelectListItem() { Value = X.UsetTypeId.ToString(), Text = X.UsetType });
            return RedirectToAction("index", "Main");
        }
    }
}