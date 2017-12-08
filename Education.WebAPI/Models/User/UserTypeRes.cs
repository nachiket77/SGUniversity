using Education.WebAPI.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Education.WebAPI.Models.User
{
    public class UserTypeRes : Response
    {
        public List<UserType> userTypeList { get; set; }
    }
    public class UserType
    {
        public string userTypeName { get; set; }
        public string userTypeId { get; set; }
    }
}