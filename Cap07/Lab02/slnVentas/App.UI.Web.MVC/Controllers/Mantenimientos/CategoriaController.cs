using App.Domain.Services;
using App.Domain.Services.Interfaces;
using App.Entities.Base;
using App.UI.Web.MVC.ModelBinders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Controllers.Mantenimientos
{
    [Authorize(Roles = "Admin")]
    public class CategoriaController : BaseController
    {
        private readonly ICategoriaService categoriaServices;

        public CategoriaController(ICategoriaService pCategoriaServices)
        {
            categoriaServices = pCategoriaServices;
        }

        // GET: Categoria
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Buscar(string filtroPorNombre)
        {
            filtroPorNombre = filtroPorNombre != null ? filtroPorNombre : "";
            var model = categoriaServices.GetAll(filtroPorNombre);
            return PartialView("IndexListado",model);
        }

        public ActionResult Create()
        {
            return PartialView();
        }
        /*
        [HttpPost]
        public ActionResult Create(Categoria model)
        {
            var result = categoriaServices.Save(model);
            return RedirectToAction("Index");
        }*/

        [HttpPost]
        public ActionResult Create(
            [ModelBinder(binderType:typeof(CategoriaBinder))]
            Categoria model)
        {
            var result = categoriaServices.Save(model);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var model = categoriaServices.GetById(id);
            return View("Create",model);
        }

        [HttpPost]
        public ActionResult Edit(Categoria model)
        {
            var result = categoriaServices.Save(model);
            return RedirectToAction("Index");
        }

    }
}