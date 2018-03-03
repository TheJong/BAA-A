using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Baaa.Startup))]
namespace Baaa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
