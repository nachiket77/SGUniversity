using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.Entity.Login
{
    public class LoginView //: IValidatableObject
    {

        public long UserID { get; set; }


        [Required(ErrorMessage = "Enter your registered Email id or Mobile no")]
        [Display(Name = "User Login Id")]
        public string LoginID { get; set; }
        [Required(ErrorMessage = "Enter valid password")]
        public string Password { get; set; }

        [Display(Name ="Login As")]
        public IEnumerable<SelectListItem> UserTypeList { get; set; }

        public int UserTypeID { get; set; }

       public string ErrorMessage { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (!string.IsNullOrEmpty(this.LoginID) && !string.IsNullOrEmpty(this.Password))
        //    {


        //    }
        //}
    }
}