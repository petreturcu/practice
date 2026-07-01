using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ExtendingWebApi.StartUp))]

namespace ExtendingWebApi
{
    using System.Web.Http;

    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            var config = new HttpConfiguration();
            DelegatingHandlersConfig.Register(config);
            RouteConfig.Register(config);
            SwaggerConfig.Register();
            app.UseWebApi(config);
        }
    }
}
