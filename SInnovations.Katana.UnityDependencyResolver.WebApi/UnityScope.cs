using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Dependencies;

namespace SInnovations.Katana.UnityDependencyResolver.WebApi
{
    public class UnityScope : IDependencyScope
    {
        protected IUnityContainer Container { get; private set; }

        public UnityScope(IUnityContainer container)
        {
            Container = container;
        }

        public object GetService(Type serviceType)
        {
            if (typeof(IHttpController).IsAssignableFrom(serviceType))
            {
                return Container.Resolve(serviceType);
            }

            try
            {
                return Container.Resolve(serviceType);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Container.ResolveAll(serviceType);
        }

        public void Dispose()
        {
            Container.Dispose();
        }
    }
}
