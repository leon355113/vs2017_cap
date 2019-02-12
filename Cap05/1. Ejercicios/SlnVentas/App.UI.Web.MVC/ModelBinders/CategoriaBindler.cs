using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.ModelBinders
{
    public class CategoriaBindler : IModelBinder
    {
        //public bool BindModel( ModelBindingExecutionContext modelBindingExecutionContext, ModelBindingContext bindingContext)
        //{
        //    Categoria model = new Categoria();
        //    var request = HttpContext.Current.Request;
        //    bindingContext.Model = model;

        //    return true;
        //}

        //Binding Manual, para casos complejos podemos aplicar esto
       public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Categoria model = new Categoria();
            model.Nombre = HttpContext.Current.Request.Form["Nombre"];
            model.Descripcion = HttpContext.Current.Request.Form["Descripcion"];

            return model;
        }
    }
}