using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Newsportal.Startup))]
namespace Newsportal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
