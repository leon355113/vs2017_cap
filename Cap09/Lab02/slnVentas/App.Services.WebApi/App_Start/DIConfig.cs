using App.Domain.Services;
using App.Domain.Services.Interfaces;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace App.Services.WebApi.App_Start
{
    public class DIConfig
    {
        public static void ConfigureDI()
        {
            var container = new Container();

            container.Options.
                DefaultScopedLifestyle 
                        = new AsyncScopedLifestyle();

            //Especificando los componentes a inyectar
            container.Register<ICategoriaService, CategoriaService>(Lifestyle.Transient);
            container.Register<IMarcaService, MarcaService>(Lifestyle.Transient);
            container.Register<IProductoService, ProductoService>(Lifestyle.Transient);
            container.Register<IUnidadMedidaService, UnidadMedidaService>(Lifestyle.Transient);
            container.Register<ISeguridadService, SeguridadService>(Lifestyle.Transient);
            container.Register<IComentarioService, ComentarioService>(Lifestyle.Transient);

            //Registrando el inyector para los controladores
            container.RegisterWebApiControllers
                            (GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                    new SimpleInjectorWebApiDependencyResolver(container);
        }

    }
}