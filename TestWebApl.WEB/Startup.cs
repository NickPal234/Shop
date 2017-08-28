using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestWebApl.WEB.Startup))]
namespace TestWebApl.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
