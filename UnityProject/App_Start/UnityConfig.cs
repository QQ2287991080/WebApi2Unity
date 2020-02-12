using System.Linq;
using System.Reflection;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;
using UnityProject.IServices;

namespace UnityProject
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            var baseType = typeof(ISuperService);
            var assemblyService = Assembly.Load("UnityProject.Services").GetTypes().Where(p => p != baseType && p.IsAssignableFrom(p));
            var assemblyIService = Assembly.Load("UnityProject.IServices").GetTypes().Where(p => p != baseType && p.IsInterface == true && p.IsAssignableFrom(p));
            foreach (var service in assemblyService)
            {
                var iService = assemblyIService.FirstOrDefault(p => p.IsAssignableFrom(service));//ÅÐ¶Ïµ±Ç°server¼Ì³ÐµÄiService
                container.RegisterType(iService, service, new HierarchicalLifetimeManager());
            }

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}