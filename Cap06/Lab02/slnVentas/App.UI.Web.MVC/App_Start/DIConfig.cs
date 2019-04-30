using App.Domain.Services;
using App.Domain.Services.Interfaces;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.App_Start
{
    public static class DIConfig
    {
        public static void ConfigureInjector()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle =
                new WebRequestLifestyle();
            //Se configuran los componentes que se quieren inyectar
            //en el proyecto
            container.Register<ICategoriaService, CategoriaService>();
            container.Register<IMarcaService, MarcaService>();
            container.Register<IProductoService, ProductoService>();
            container.Register<IUnidadMedidaService, UnidadMedidaService>();
            container.Register<ISeguridadService, SeguridadService>();
            container.Register<IComentarioService, ComentarioService>();
            //---
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Verify();
            DependencyResolver.SetResolver(
                new SimpleInjectorDependencyResolver(container)
                );

        }

    }
}