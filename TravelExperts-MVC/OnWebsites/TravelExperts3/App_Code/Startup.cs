using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TravelExperts3.Startup))]
namespace TravelExperts3
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
