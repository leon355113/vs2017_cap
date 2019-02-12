using App.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Entities.Base;

namespace App.UI.Web.MVC.Controllers.Mantenimientos
{
    public class MarcaController : Controller
    {
        private readonly MarcaService marcaServices;

        public MarcaController()
        {
            marcaServices = new MarcaService();
        }

        // GET: Marca
        public ActionResult Index()
        {
            var model = marcaServices.GetAll("");
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Marca model)
        {
            var result = marcaServices.Save(model);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var model = marcaServices.GetById(id);
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult Edit(Marca model)
        {
            var result = marcaServices.Save(model);
            return RedirectToAction("Index");
        }
    }
}