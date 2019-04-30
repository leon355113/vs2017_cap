using App.Domain.Services;
using App.Domain.Services.Interfaces;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Controllers.Mantenimientos
{
    public class ErrorController : BaseController
    {
        
        // GET: Categoria
        public ActionResult NoFound()
        {
            return View();
        }

        
    }
}