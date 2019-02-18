using App.Domain.Services;
using App.Domain.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Controllers.Mantenimientos
{
    public class ProductoController : Controller
    {
        private readonly IProductoService productoService;
        private readonly ICategoriaService categoriaService;
        public ProductoController()
        {
            productoService = new ProductoService();
            categoriaService = new CategoriaService();
        }

        // GET: Producto
        public ActionResult Index(string filterByName, int? filterByCategoria)
        {
            filterByName = string.IsNullOrWhiteSpace(filterByName) ? "" : filterByName.Trim();
            ViewBag.filterByName = filterByName;
            ViewBag.Categorias = categoriaService.GetAll("");

            var model = productoService.GetAll(filterByName, filterByCategoria);
            return View(model);
        }

        // GET: Producto
        public ActionResult Index2(string filterByName, int? filterByCategoria)
        {
            filterByName = string.IsNullOrWhiteSpace(filterByName) ? "" : filterByName.Trim();            
            ViewBag.Categorias = categoriaService.GetAll("");

            //var model = productoService.GetAll(filterByName, filterByCategoria);
            return View();
        }

        public ActionResult Index2Buscar(string filterByName, int? filterByCategoria)
        {
            filterByName = string.IsNullOrWhiteSpace(filterByName) ? "" : filterByName.Trim();

            var model = productoService.GetAll(filterByName, filterByCategoria);

            return PartialView("Index2Resultado",model);
        }
        // GET: Producto
        public ActionResult Index3(string filterByName, int? filterByCategoria)
        {
            ViewBag.Categorias = categoriaService.GetAll("");
            return View();
        }

        public JsonResult Index3Buscar(string filterByName, int? filterByCategoria)
        {
            filterByName = string.IsNullOrWhiteSpace(filterByName) ? "" : filterByName.Trim();

            var model = productoService.GetAll(filterByName, filterByCategoria);

            JsonSerializerSettings config = new JsonSerializerSettings { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore };
            var model2 = JsonConvert.SerializeObject(model, Formatting.Indented, config);

         

            return Json(model2);
        }
    }
}