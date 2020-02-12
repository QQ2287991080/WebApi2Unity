using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Unity;

namespace UnityProject.App_Start
{
    public class UnityResolver : IDependencyResolver
    {
        protected IUnityContainer _Container;
        public UnityResolver(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("Container");
            }
            _Container = container;
        }
        public object GetService(Type serviceType)
        {
            try
            {
                return _Container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }

        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _Container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
                throw;
            }
        }
        public IDependencyScope BeginScope()
        {
            var child = _Container.CreateChildContainer();//创建子容器
            return new UnityResolver(child);//解析
        }

        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            _Container.Dispose();

        }
    }
}