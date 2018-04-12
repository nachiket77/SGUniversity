using Education.Core;
using Education.WebAPI.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Linq;
using System.Security.Claims;
using Newtonsoft.Json;
using System.Text;
using Education.Entity.Login;
using System.Threading.Tasks;
using System.Configuration;

namespace Education.WebAPI.Controllers
{
    //[RoutePrefix("api/User")]
    public class LoginController : ApiController
    {
        public IUserReposetory _UserReporsetory;

        public LoginController(IUserReposetory _repo)
        {
            _UserReporsetory = _repo;
        }



        [HttpPost]
        [Route("api/Authenticate")]
        public async Task<HttpResponseMessage> Index([FromBody]AuthenticateModel model)
        {
            //      List<TestSchedule> testDetails = _ITestDetailsRepository.GetTestDetailsForAPI();
            string tokenPath = ConfigurationManager.AppSettings["TokenAPI"];
            AccessModel accessModel = new AccessModel();
            Login login = new Login() { LoginID = model.UserName, Password = model.Password, UserTypeID = model.UserTypeId };

            LoginResponse loginResponse = _UserReporsetory.Login(login);
            if (loginResponse != null && loginResponse.UserID > 0)
            {
                var client = new HttpClient()
                {
                    BaseAddress = new Uri(Request.RequestUri.GetLeftPart(UriPartial.Authority))
                };

                var content = new FormUrlEncodedContent(new[]
                                                        {
                                                        new KeyValuePair<string, string>("grant_type", "password"),
                                                        new KeyValuePair<string, string>("username", model.UserName),
                                                        new KeyValuePair<string, string>("password", model.Password)
                                                        //new KeyValuePair<string, string>("UserTypeID", Convert.ToString(model.UserTypeId))
                                                        });

                var result = await client.PostAsync(tokenPath, content);
                string resultContent = await result.Content.ReadAsStringAsync();
                //resultContent = resultContent.Replace(".issued", "issued").Replace(".expires", "expires");
                accessModel = JsonConvert.DeserializeObject<AccessModel>(resultContent);

                accessModel.UserID = loginResponse.UserID;
                accessModel.LoginEmail = loginResponse.LoginEmail;
                accessModel.LoginMobile = loginResponse.LoginMobile;
                accessModel.CreatedDate = loginResponse.CreatedDate;
                accessModel.ModifiedDate = loginResponse.ModifiedDate;
                accessModel.PasswordRetryCount = loginResponse.PasswordRetryCount;
                accessModel.UserTypeID = loginResponse.UserTypeID;
                accessModel.ErrorMessage = loginResponse.ErrorMessage;
            }
            else
            {
                accessModel.ErrorMessage = loginResponse.ErrorMessage;
            }

            return new HttpResponseMessage() { Content = new StringContent(JsonConvert.SerializeObject(accessModel), Encoding.UTF8, "application/json") };
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/data/forall")]

        public IHttpActionResult Get()
        {
            return Ok("Now server time is" + DateTime.Now.ToString());
        }

        [Authorize]
        [HttpGet]
        [Route("api/data/authenticate")]
        public IHttpActionResult GetForAuthenticate()
        {
            var identity = (ClaimsIdentity)User.Identity;
            return Ok("Hello" + identity.Name);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("api/data/authorize")]

        public IHttpActionResult GetForAdmin()
        {
            var Identity = (ClaimsIdentity)User.Identity;
            var roles = Identity.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
            return Ok("Hello" + Identity.Name + "Role:" + string.Join(",", roles.ToList()));
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
            catch (Exception ex)
            {
                objResponse.ResponseCode = "100";
                objResponse.ResponseMessage = ex.Message;
            }
            return objResponse;

        }



    }
}
