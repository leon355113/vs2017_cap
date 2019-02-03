using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Entities.Base;
using App.Domain.Services;

namespace App.UI.Web.MVC.Controllers.Mantenimientos
{
    public class MarcaController : Controller
    {

        private readonly MarcaService marcaServicio;
        
        // GET: Marca
        public ActionResult Index()
        {
            var model = marcaServicio.GetAll("");
            return View(model);

        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Marca model)
        {
            var result = marcaServicio.Save(model);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var model = marcaServicio.getById(id);
            return View("Create", model);//Reutilizando la vista create para la edicion
        }

        [HttpPost]
        public ActionResult Edit(Marca model)
        {
            var result = marcaServicio.Save(model);
            return RedirectToAction("Index");
        }

    }
}