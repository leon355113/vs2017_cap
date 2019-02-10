using App.Domain.Services;
using App.Domain.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Entities.Base;

namespace App.UI.Web.MVC.Controllers.Mantenimientos
{
    public class ProductoController : Controller
    {
        private readonly IProductoService productoService;
        private readonly ICategoriaService categoriaService;

        public ProductoController()
        {
            productoService = new ProductoService();
        }

        // GET: Producto
        public ActionResult Index(string filterByName,int? filterbyCategoria)
        {
            filterByName = string.IsNullOrWhiteSpace(filterByName) ? "" : filterByName.Trim();
            ViewBag.filterByName = filterByName;
            ViewBag.Categorias = categoriaService.GetAll("");

            var model = productoService.GetAll(filterByName,filterbyCategoria);
            return View(model);
        }

        // GET: Producto
        public ActionResult Index2(string filterByName, int? filterbyCategoria)
        {
            filterByName = string.IsNullOrWhiteSpace(filterByName) ? "" : filterByName.Trim();
            ViewBag.filterByName = filterByName;
            ViewBag.Categorias = categoriaService.GetAll("");

            var model = productoService.GetAll(filterByName, filterbyCategoria);
            return View(model);
        }

        public ActionResult Index3(string filterByName, int? filterbyCategoria)
        {
            ViewBag.Categorias = categoriaService.GetAll("");

            var model = productoService.GetAll(filterByName, filterbyCategoria);
            return View();
        }
        public ActionResult Index2Buscar(string filterByName, int? filterbyCategoria)
        {
            filterByName = string.IsNullOrWhiteSpace(filterByName) ? "" : filterByName.Trim();

            var model = productoService.GetAll(filterByName, filterbyCategoria);
            return PartialView("Index2Resultado", model);
        }
        public JsonResult Index3Buscar(string filterByName, int? filterbyCategoria)
        {
            filterByName = string.IsNullOrWhiteSpace(filterByName) ? "" : filterByName.Trim();

            var model = productoService.GetAll(filterByName, filterbyCategoria);

            JsonSerializerSettings Config = new JsonSerializerSettings{
                ReferenceLoopHandling =Newtonsoft.Json.ReferenceLoopHandling.Ignore};

            var model2 = JsonConvert.SerializeObject(model, Formatting.Indented, Config);

            return Json(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Producto model)
        {
            var result = productoService.Save(model);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var model = productoService.GetById(id);
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult Edit(Producto model)
        {
            var result = productoService.Save(model);
            return RedirectToAction("Index");
        }

    }
}