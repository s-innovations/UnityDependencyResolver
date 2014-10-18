using Microsoft.Practices.Unity;
using Owin;
using SInnovations.Katana.UnityDependencyResolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owin
{
    public static class OwinAppBuilderExtensions
    {
        public const string UnityRequestContainerKey = "UnityRequestContainer";
        public const string UnityUnityContainerKey = "UnityContainer";

        public static IUnityContainer UseUnityContainer(this IAppBuilder app)
        {

            var container = new UnityContainer();
            app.Properties.Add(UnityUnityContainerKey, container);
            app.Use(typeof(UnityContainerMiddleware), container);
            return container;
        }

        public static IUnityContainer GetUnityContainer(this IAppBuilder app)
        {
            return app.Properties[UnityUnityContainerKey] as IUnityContainer;
        }
    }
}
