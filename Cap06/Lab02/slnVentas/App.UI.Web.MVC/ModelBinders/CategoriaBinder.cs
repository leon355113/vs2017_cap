using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.ModelBinders
{
    public class CategoriaBinder : IModelBinder
    {

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Categoria model = new Categoria();
            model.Nombre = HttpContext.Current.Request.Form["Nombre"];
            model.Descripcion = HttpContext.Current.Request.Form["Descripcion"];

            return model;
        }
    }
}