using App.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Entities.Base;

namespace App.UI.Web.MVC.Controllers.Mantenimientos
{
    public class CategoriaController : Controller
    {
        private readonly CategoriaService categoriaServices;

        public CategoriaController()
        {
            categoriaServices = new CategoriaService();
        }

        // GET: Categoria
        public ActionResult Index()
        {
            //El modelo vendria a ser una lista, una entidad, por lo tanto a nivel de la vista debe recepcionar el mismo modelo que se envia sea entidad o lista
            var model = categoriaServices.GetAll("");
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Categoria model)
        {
            var result = categoriaServices.Save(model);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var model = categoriaServices.GetById(id);
            return View("Create",model);//Reutilizando la vista create para la edicion
        }

        [HttpPost]
        public ActionResult Edit(Categoria model)
        {
            var result = categoriaServices.Save(model);
            return RedirectToAction("Index");
        }

    }
}