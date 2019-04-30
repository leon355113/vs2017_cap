using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab02Templates.Startup))]
namespace Lab02Templates
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
