using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mtbuddies.Startup))]
namespace mtbuddies
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
