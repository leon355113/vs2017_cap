using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace App.UI.Web.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*1. Ruta estatica*/
            routes.MapRoute(
                name: "rutaEstaticaCatalogo",
                url: "Catalogo",
                defaults: new
                {
                    controller ="Producto",
                    action="Index2"
                }
                );

            /*2. Ruta SEO*/
            routes.MapRoute(
                name: "rutaSEOCatalogo",
                url: "Catalogo/{id}/{name}",
                defaults: new
                {
                    controller = "Producto",
                    action = "Edit"
                }
                );

            /* Mapa de rutas por decto debe ir al final*/
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
