using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GPromice.Startup))]
namespace GPromice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
