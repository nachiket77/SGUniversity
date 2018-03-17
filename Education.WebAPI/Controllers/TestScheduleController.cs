using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Education.Core.Admin;
using Education.Entity.Admin.Test;
using Education.Entity.Admin;
using System.Xml.Linq;

namespace Education.WebAPI.Controllers
{
    public class TestScheduleController : ApiController
    {

        ITestDetailsRepository _ITestDetailsRepository;

        public TestScheduleController(ITestDetailsRepository repo)
        {
            _ITestDetailsRepository = repo;
        }

        [Authorize]
        [HttpPost]
        [Route("api/TestSchedule")]
        public HttpResponseMessage Index([FromBody]Student user)
        {
            List<TestTypeModel> lstTestDetailsModel = _ITestDetailsRepository.GetTestDetailsForAPI(user.StudentId);

            return new HttpResponseMessage() { Content = new StringContent(JsonConvert.SerializeObject(lstTestDetailsModel), Encoding.UTF8, "application/json") };
        }


        [Authorize]
        [HttpPost]
        [Route("api/TestQuestion")]
        public HttpResponseMessage TestQuestion([FromBody]Test test)
        {
           // test.TestId = 2;
            List<TestQuestion> testDetails = _ITestDetailsRepository.GetTestQuestionForAPI(test.TestId);

            return new HttpResponseMessage() { Content = new StringContent(JsonConvert.SerializeObject(testDetails), Encoding.UTF8, "application/json") };
        }

        [Authorize]
        [HttpPost]
        [Route("api/TestAnswer")]
        public HttpResponseMessage TestAnswer([FromBody]TestAnswerModel model)
        {
            var questAnsXml = new XElement("ds",
               from a in model.lstQuesAns
               select new XElement("dt",
                                   //new XAttribute("ID", a.QuestionId),
                                   new XElement("QuestionId", a.QuestionId),
                                   new XElement("AnswerId", a.AnswerId),
                                   new XElement("Remark", a.Remark)

                          )).ToString();
            TestProgressModel res = _ITestDetailsRepository.SaveTestAnswers(model.TestId, model.SubjectId, model.StartTime, model.EndTime, model.StudentId, questAnsXml);

            return new HttpResponseMessage() { Content = new StringContent(JsonConvert.SerializeObject(res), Encoding.UTF8, "application/json") };
        }

    }
}
