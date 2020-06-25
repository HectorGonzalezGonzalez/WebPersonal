using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebPersonal.Startup))]
namespace WebPersonal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
