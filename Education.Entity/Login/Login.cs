﻿using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Entity.Login
{
    public class Login
    {

        public long UserID { get; set; }



        public string LoginID { get; set; }

        public string Password { get; set; }

        public int UserTypeID { get; set; }

        public string Message { get; set; }


     

    }

    // Added by Pramod

    public class AuthenticateModel
    {
        public int UserTypeId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }

    public class AccessModel
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }

        public long UserID { get; set; }
        public string LoginEmail { get; set; }
        public string LoginMobile { get; set; }
        public int StatusID { get; set; }
        public int UserTypeID { get; set; }
        public int PasswordRetryCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ErrorMessage { get; set; }
    }
}
