using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using UnityProject.App_Start;
using UnityProject.IServices;
using UnityProject.Services;

namespace UnityProject
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //创建容器
            var container = new UnityContainer();
            var baseType = typeof(ISuperService);
            var assemblyService = Assembly.Load("UnityProject.Services").GetTypes().Where(p => p != baseType && p.IsAssignableFrom(p));
            var assemblyIService = Assembly.Load("UnityProject.IServices").GetTypes().Where(p => p != baseType && p.IsInterface == true && p.IsAssignableFrom(p));
            foreach (var service in assemblyService)
            {
                var iService = assemblyIService.FirstOrDefault(p => p.IsAssignableFrom(service));//判断当前server继承的iService
                container.RegisterType(iService, service, new HierarchicalLifetimeManager());
            }
            //container.RegisterType<IStudentService,StudentService>(new HierarchicalLifetimeManager());//interface必须放在第一位
            config.DependencyResolver = new UnityResolver(container);//解析依赖
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
