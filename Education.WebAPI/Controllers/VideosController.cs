using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Education.Core.Admin;
using Education.Entity.Admin;
using Newtonsoft.Json;
using System.Text;

namespace Education.WebAPI.Controllers
{

    public class VideosController : ApiController
    {
        IVideoUpload _VideoUpload;

        public VideosController(IVideoUpload repo)
        {
            _VideoUpload = repo;
        }

        [Authorize]
        [HttpPost]
        [Route("api/RecommendedVideos")]
        public HttpResponseMessage Index([FromBody]Student user)
        {
            List<RecommendedVideoModel> objvideoupload = new List<RecommendedVideoModel>();
            //int? studentId =  Convert.ToInt32(userId);
            objvideoupload = _VideoUpload.GET_RecommendedVideos(user.StudentId);
            //return objvideoupload;

            return new HttpResponseMessage() { Content = new StringContent(JsonConvert.SerializeObject(objvideoupload), Encoding.UTF8, "application/json") };
        }

        [Authorize]
        [HttpPost]
        [Route("api/PopularVideos")]
        public HttpResponseMessage PopularVideos([FromBody]Student user)
        {
            List<PopularVideoModel> objvideoupload = new List<PopularVideoModel>();
            //int? studentId =  Convert.ToInt32(userId);
            objvideoupload = _VideoUpload.GET_PopularVideos(user.StudentId);
            //return objvideoupload;

            return new HttpResponseMessage() { Content = new StringContent(JsonConvert.SerializeObject(objvideoupload), Encoding.UTF8, "application/json") };
        }

        [Authorize]
        [HttpPost]
        [Route("api/GetVideosDetails")]
        public HttpResponseMessage GetVideosDetails([FromBody]Video model)
        {
            VideoDetailsViewModel objvideo = new VideoDetailsViewModel();
            //int? studentId =  Convert.ToInt32(userId);
            objvideo = _VideoUpload.GET_VideoDetails(model.VideoId);
            //return objvideoupload;

            return new HttpResponseMessage() { Content = new StringContent(JsonConvert.SerializeObject(objvideo), Encoding.UTF8, "application/json") };
        }
    }
}
