using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutoBiller.WebMVC.Startup))]
namespace AutoBiller.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
