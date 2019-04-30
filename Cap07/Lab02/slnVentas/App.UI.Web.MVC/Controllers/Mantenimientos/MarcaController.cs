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
    [Authorize(Roles = "Admin")]
    public class MarcaController : BaseController
    {
        private readonly IMarcaService marcaService;

        public MarcaController()
        {
            marcaService = new MarcaService();
        }

        // GET: Marca
        public ActionResult Index()
        {
            var model = marcaService.GetAll("");
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Marca model)
        {
            var result = marcaService.Save(model);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var model = marcaService.GetById(id);
            return View("Create", model);

        }

        [HttpPost]
        public ActionResult Edit(Marca model)
        {
            var result = marcaService.Save(model);

            return RedirectToAction("Index");
        }
    }
}