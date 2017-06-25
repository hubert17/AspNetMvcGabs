using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyAspNetMvcApp.Startup))]
namespace MyAspNetMvcApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
