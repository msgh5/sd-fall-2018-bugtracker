using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GuiBugTracker.Startup))]
namespace GuiBugTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
