using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Filters
{
    public class HandleCustomError:HandleErrorAttribute
    {
        public static readonly log4net.ILog log =
           log4net.LogManager.GetLogger(
           MethodBase.GetCurrentMethod().DeclaringType);

        public override void OnException(ExceptionContext filterContext)
        {

            var viewResult = new ViewResult() { ViewName = "Error" };
            filterContext.Result = viewResult;
            filterContext.ExceptionHandled = true;

            log.Error(filterContext.Exception);

            base.OnException(filterContext);
        }
    }
}