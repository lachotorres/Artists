using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Artists.Startup))]
namespace Artists
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
