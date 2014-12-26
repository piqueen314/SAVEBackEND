using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SaveOrg.Startup))]
namespace SaveOrg
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
