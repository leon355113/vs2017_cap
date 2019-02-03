using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Entities.Base;
using App.Domain.Services;

namespace App.UI.Web.MVC.Controllers.Mantenimientos
{
    public class UnidadMedidaController : Controller
    {
        private readonly UnidadMedidaService unidadmedidaServicio;
        // GET: UnidadMedida
        public UnidadMedidaController()
        {
            unidadmedidaServicio = new UnidadMedidaService();
        }


        public ActionResult Index()
        {
            //El modelo vendria a ser una lista, una entidad, por lo tanto a nivel de la vista debe recepcionar el mismo modelo que se envia sea entidad o lista
            var model = unidadmedidaServicio.GetAll("");
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UnidadMedida model)
        {
            var result = unidadmedidaServicio.Save(model);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var model = unidadmedidaServicio.GetById(id);
            return View("Create", model);//Reutilizando la vista create para la edicion
        }

        public ActionResult Edit(UnidadMedida model)
        {
            var result = unidadmedidaServicio.Save(model);
            return RedirectToAction("Index");
        }

    }
}