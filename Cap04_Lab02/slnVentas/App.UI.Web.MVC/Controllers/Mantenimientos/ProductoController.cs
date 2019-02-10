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
        private readonly ProductoService productoServices;
        private readonly CategoriaService categoriaServices;
        private readonly MarcaService marcaServices;

        public ProductoController()
        {
            productoServices = new ProductoService();
            categoriaServices = new CategoriaService();
           marcaServices = new MarcaService();
        }

        // GET: Producto//con un string no habria problemas ya que ello soportan nulos int? filterByCategoria, hay que ponerlo en este caso al entero de manera explicita que soporte nulos
        //cuando es nullo el parametro filterByCategoria (se ha elegido Todos)
        //**SIN AJAX
        public ActionResult Index(string filterByName, int? filterByCategoria, int? filterByMarca)
        {
            filterByName = string.IsNullOrWhiteSpace(filterByName) ? "" : filterByName.Trim();
            ViewBag.filterByName = filterByName;
            ViewBag.Categorias = categoriaServices.GetAll("");
            ViewBag.Marcas = marcaServices.GetAll("");

            var model = productoServices.GetAll(filterByName, filterByCategoria, filterByMarca);
            return View(model);
        }

        //**CON AJAX
        public ActionResult Index2(string filterByName, int? filterByCategoria, int? filterByMarca)
        {
            //Como ya no vamos a recargar toda la pagina ya no necesitamos asignar el valor a la cada de texto filterByName, esta caja ya no se va limpiar
            ViewBag.Categorias = categoriaServices.GetAll("");
            ViewBag.Marcas = marcaServices.GetAll("");

            return View();
        }

        //**VIEWPARTIAL AJAX
        public ActionResult Index2Buscar(string filterByName, int? filterByCategoria, int? filterByMarca)
        {
            filterByName = string.IsNullOrWhiteSpace(filterByName) ? "" : filterByName.Trim();


            var model = productoServices.GetAll(filterByName, filterByCategoria, filterByMarca);
            return PartialView("_Index2Resultado", model);
        }


        //GET PRODUCTO
        public ActionResult Index3(string filterByName, int? filterByCategoria, int? filterByMarca)
        {
            ViewBag.Categorias = categoriaServices.GetAll("");
            ViewBag.Marcas = marcaServices.GetAll("");

            return View();
        }

        public JsonResult Index3Buscar(string filterByName, int? filterByCategoria, int? filterByMarca)
        {
            filterByName = string.IsNullOrWhiteSpace(filterByName) ? "" : filterByName.Trim();
            var model = productoServices.GetAll(filterByName, filterByCategoria, filterByMarca);

            JsonSerializerSettings config = new JsonSerializerSettings { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore };
            var model2 = JsonConvert.SerializeObject(model, Formatting.Indented, config);

            return Json(model2);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Producto model)
        {
            var result = productoServices.Save(model);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var model = productoServices.GetById(id);
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult Edit(Producto model)
        {
            var result = productoServices.Save(model);
            return RedirectToAction("Index");
        }

    }
}