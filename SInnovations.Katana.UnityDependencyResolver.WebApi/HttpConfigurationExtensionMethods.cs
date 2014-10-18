using SInnovations.Katana.UnityDependencyResolver.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Http
{
    public static class HttpConfigurationExtensionMethods
    {

        public static void AddKatanaUnityDependencyResolver(this HttpConfiguration configuration)
        {
            configuration.MessageHandlers.Insert(0, new KatanaUnityDependencyResolver());
        }
    }
}
