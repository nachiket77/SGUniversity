using Education.Core;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using Education.Core.Admin;

namespace Education.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUserReposetory, UserReposetory>();
            container.RegisterType<IVideoUpload, VideoUpload>();
            container.RegisterType<ITestDetailsRepository, TestDetailsRepository>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}