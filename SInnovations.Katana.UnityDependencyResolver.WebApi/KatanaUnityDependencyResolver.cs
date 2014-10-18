using Microsoft.Practices.Unity;
using Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Hosting;

namespace SInnovations.Katana.UnityDependencyResolver.WebApi
{
    public class KatanaUnityDependencyResolver : DelegatingHandler
    {
        
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var owin = request.GetOwinContext();
            var scope = owin.Get<IUnityContainer>(OwinAppBuilderExtensions.UnityRequestContainerKey);
            if (scope != null)
            {
                request.Properties[HttpPropertyKeys.DependencyScope] = new UnityScope(scope);
            }
            else
            {
                Trace.TraceWarning("{0} not regiested (no dependency injeciton on controllers), have you run UseUnityDependency");
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}
