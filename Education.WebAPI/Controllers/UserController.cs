using Education.Core;
using Education.Entity.Admin;
using Education.Entity.Login;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace Education.WebAPI.Controllers
{
    public class UserController : ApiController
    {
        public IUserReposetory _UserReporsetory;

        public UserController(IUserReposetory _repo)
        {
            _UserReporsetory = _repo;
        }

        [Authorize]
        [HttpPost]
        [Route("api/GetProfile")]
        public HttpResponseMessage Profile([FromBody]UserModel user)
        {
            ProfileModel model = _UserReporsetory.GetProfile(user.UserId);

            return new HttpResponseMessage() { Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json") };

        }

    }
}
