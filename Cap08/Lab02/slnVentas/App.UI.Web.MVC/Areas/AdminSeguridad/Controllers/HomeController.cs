using App.Domain.Services.Interfaces;
using App.UI.Web.MVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Areas.Seguridad.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ISeguridadService seguridadService;
        private readonly IProductoService productoService;

        public HomeController(ISeguridadService pSeguridadService,
                        IProductoService pProductoService
            )
        {
            seguridadService = pSeguridadService;
            productoService = pProductoService;
        }

        // GET: Seguridad/Home
        public ActionResult Index()
        {
            var model = seguridadService.GetAll("");
            return View(model);
        }

        // GET: Seguridad/Home
        public ActionResult Buscar(string FiltroPorNombre)
        {
            FiltroPorNombre = FiltroPorNombre ?? "";
            var model = seguridadService.GetAll(FiltroPorNombre);
            return PartialView("BuscarListado", model);
        }
    }
}