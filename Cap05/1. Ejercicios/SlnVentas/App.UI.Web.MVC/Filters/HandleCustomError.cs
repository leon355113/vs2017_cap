using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Filters
{
    public class HandleCustomError : HandleErrorAttribute
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        //Se aplica sin try catch(en errores no controlados), esto se ejecuta 
        public override void OnException(ExceptionContext filterContext)
        {
            //Creando una instancia de un ViewResult
            var _viewResult = new ViewResult() { ViewName = "Error" };
            filterContext.Result = _viewResult;
            filterContext.ExceptionHandled = true;
            
            log.Error(filterContext.Exception);
            base.OnException(filterContext);
        }
    }
}