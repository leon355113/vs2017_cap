using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(App.UI.Web.MVC.Startup))]

namespace App.UI.Web.MVC
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(
                new CookieAuthenticationOptions
                {
                    AuthenticationType="ApplicationCookie",
                    CookieName ="AuthSistemaComercio",
                    ExpireTimeSpan=TimeSpan.FromHours(1),
                    LoginPath = new PathString("/Seguridad/Login")
                }
                );
        }
    }
}
