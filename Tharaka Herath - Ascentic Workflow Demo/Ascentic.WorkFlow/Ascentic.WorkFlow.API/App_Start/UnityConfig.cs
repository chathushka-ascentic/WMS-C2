using Ascentic.WorkFlow.Contracts.Interfaces;
using Ascentic.WorkFlow.EndSystems.Repositories;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Ascentic.WorkFlow.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<ITaskRepository, TaskRepository>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}