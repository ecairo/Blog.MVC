using Blog.App_Start;
using Blog.Helpers;
using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using System.Web.Http;

[assembly: OwinStartup(typeof(Blog.Startup))]

namespace Blog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            // ConfigureAuth(app);

            app.ConfigureAuth();
            app.SetWebApiContainer();
        }
    }
}
