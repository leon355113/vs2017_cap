using App.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Entities.Base;
using Newtonsoft.Json;
using App.UI.Web.MVC.ActionFilters;
using App.UI.Web.MVC.Filters;
using System.Reflection;
using App.UI.Web.MVC.Models.ViewModels;

namespace App.UI.Web.MVC.Controllers.Mantenimientos
{
   
    public class ProductoController : BaseController//Hereda de la clase base base controler para guardar log
    {
         
        private readonly ProductoService productoServices;
        private readonly CategoriaService categoriaServices;
        private readonly MarcaService marcaServices;
        private readonly UnidadMedidaService unidadMedidaServices;
         

        public ProductoController()
        {
            productoServices = new ProductoService();
            categoriaServices = new CategoriaService();
            marcaServices = new MarcaService();
            unidadMedidaServices = new UnidadMedidaService();
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
            try
            {
                //Como ya no vamos a recargar toda la pagina ya no necesitamos asignar el valor a la cada de texto filterByName, esta caja ya no se va limpiar
                ViewBag.Categorias = categoriaServices.GetAll("");
                ViewBag.Marcas = marcaServices.GetAll("");

                throw new Exception("Lanzando un error simulado");

            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
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

            return Json( model2);
        }



        public ActionResult Create()
        {
            ViewBag.Categorias = categoriaServices.GetAll("");
            ViewBag.Marcas = marcaServices.GetAll("");
            ViewBag.UnidadesMedidas = unidadMedidaServices.GetAll("");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Producto model)
        {
            Guid obj = Guid.NewGuid();
            model.FechaCreacion = DateTime.Now;
            model.UsuarioCreador = obj;
            var result = productoServices.Save(model);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Categorias = categoriaServices.GetAll("");
            ViewBag.Marcas = marcaServices.GetAll("");
            ViewBag.UnidadesMedidas = unidadMedidaServices.GetAll("");
            var model = productoServices.GetById(id);
            return View("Create", model);//Reutilizando la vista create para la edicion
        }

        [HttpPost]
        public ActionResult Edit(Producto model)
        {

            Guid obj = Guid.NewGuid();
            model.FechaModificacion = DateTime.Now;
            model.UsuarioModificador = obj;
            var result = productoServices.Save(model);
            return RedirectToAction("Index");
        }


        public ActionResult IndexVM(ProductoSearchViewModel model)
        {
            model.categorias = categoriaServices.GetAll("").ToList() ;
            model.marcas = marcaServices.GetAll("").ToList();

            var filterByName = string.IsNullOrWhiteSpace(model.filterByName) ? "" : model.filterByName.Trim();

            model.productos = productoServices.GetAll(filterByName, model.filterByCategoria, model.filterByMarca).ToList();
            return View(model);
        }

    }
}