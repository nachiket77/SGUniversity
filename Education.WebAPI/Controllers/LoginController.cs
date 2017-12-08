using Education.Core;
using Education.WebAPI.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Linq;

namespace Education.WebAPI.Controllers
{
    [RoutePrefix("api/User")]
    public class LoginController : ApiController
    {
        
        public IUserReposetory _UserReporsetory;

        public LoginController(IUserReposetory _repo)
        {
            _UserReporsetory = _repo;
        }

        [HttpGet]
        [Route("GetUserType")]
        public UserTypeRes GetUserType()
        {
            UserTypeRes objResponse = new UserTypeRes();
            try
            {
                
                objResponse.userTypeList = new List<UserType>();
                var usertype = _UserReporsetory.GetUserType();
                objResponse.ResponseCode = "0";
                objResponse.ResponseMessage = "success";
                if (usertype != null)
                {
                    foreach (var item in usertype)
                    {
                        UserType obj = new UserType();
                        obj.userTypeId = Convert.ToString(item.UsetTypeId);
                        obj.userTypeName = item.UsetType;
                        objResponse.userTypeList.Add(obj);
                    }
                }
            }
            catch(Exception ex)
            {
                objResponse.ResponseCode = "100";
                objResponse.ResponseMessage = ex.Message;
            }
            return objResponse;

        }

        

    }
}
