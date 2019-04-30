using System.Web.Mvc;

namespace App.UI.Web.MVC.Areas.Seguridad
{
    public class SeguridadAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdminSeguridad";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Seguridad_default",
                "AdminSeguridad/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}