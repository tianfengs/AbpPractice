using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MvcAppTest.Startup))]
namespace MvcAppTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
