using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Entity.Login
{
  public  class LoginResponse
    {
        public long UserID { get; set; }
        public string LoginEmail { get; set; }
        public string LoginMobile { get; set; }
        public string Password { get; set; }
        public int StatusID { get; set; }
        public int UserTypeID { get; set; }
        public int PasswordRetryCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public string ErrorMessage { get; set; }
    }

   
}
