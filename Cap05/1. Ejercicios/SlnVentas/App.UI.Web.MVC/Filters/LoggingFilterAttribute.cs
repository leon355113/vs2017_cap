using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.ActionFilters
{
    public class LoggingFilterAttribute: ActionFilterAttribute
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        //Metodo que se ejecuta antes de iniciar la accion (Action)
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var message = $"Iniciando la ejecución del contralador: " + $" { filterContext.ActionDescriptor.ControllerDescriptor.ControllerName}" + 
              $", Action: {filterContext.ActionDescriptor.ActionName}" + 
              $",Hora de inicio: {DateTime.Now}";

            log.Info(message);

            base.OnActionExecuting(filterContext);
        }

        //Metodo que se ejecuta despues de finalizar la accion (Action)
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var message = $"Finalizando la ejecución del contralador: " + $" { filterContext.ActionDescriptor.ControllerDescriptor.ControllerName}" +
             $", Action: {filterContext.ActionDescriptor.ActionName}" +
             $",Hora de fin: {DateTime.Now}";

            log.Info(message);

            base.OnActionExecuted(filterContext);
        }
    }
}