using App.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Entities.Base;

namespace App.UI.Web.MVC.Controllers.Mantenimientos
{
    public class UnidadMedidaController : Controller
    {
        private readonly UnidadMedidaService unidadMedidaServices;
        public UnidadMedidaController()
        {
            unidadMedidaServices = new UnidadMedidaService();
        }
        // GET: UnidadMedida
        public ActionResult Index()
        {
            var model = unidadMedidaServices.GetAll("");
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UnidadMedida model)
        {
            var result = unidadMedidaServices.Save(model);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var model = unidadMedidaServices.GetById(id);
            return View("Create", model);//Reutilizando la vista create para la edicion
        }

        [HttpPost]
        public ActionResult Edit(UnidadMedida model)
        {
            var result = unidadMedidaServices.Save(model);
            return RedirectToAction("Index");
        }

    }
}