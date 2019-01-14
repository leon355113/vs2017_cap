using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cibertect.UI.MVC.Startup))]
namespace Cibertect.UI.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
