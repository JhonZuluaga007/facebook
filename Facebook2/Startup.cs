using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Facebook2.Startup))]
namespace Facebook2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
