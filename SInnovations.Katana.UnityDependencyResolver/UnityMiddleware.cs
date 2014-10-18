using Microsoft.Practices.Unity;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SInnovations.Katana.UnityDependencyResolver
{
   
    public class UnityContainerMiddleware
    {
        readonly private Func<IDictionary<string, object>, Task> _next;
        readonly private IUnityContainer _container;

        public UnityContainerMiddleware(Func<IDictionary<string, object>, Task> next, IUnityContainer container)
        {
            _next = next;
            _container = container;
        }

        public async Task Invoke(IDictionary<string, object> env)
        {
            // this creates a per-request, disposable scope
            using (var scope = _container.CreateChildContainer())
            {
                // this makes scope available for downstream frameworks
                env[OwinAppBuilderExtensions.UnityRequestContainerKey] = scope;
                await _next(env);
            }
        }
    }
}
