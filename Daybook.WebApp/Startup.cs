using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Daybook.WebApp.Startup))]
namespace Daybook.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
