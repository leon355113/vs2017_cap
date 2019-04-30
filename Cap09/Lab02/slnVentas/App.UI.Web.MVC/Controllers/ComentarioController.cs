using App.Domain.Services.Interfaces;
using App.Entities.Base;
using App.UI.Web.MVC.Models.ViewModels;
using AutoMapper;
using Microsoft.Security.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Controllers
{
    public class ComentarioController : BaseController
    {
        private readonly IComentarioService comentarioService;
        public ComentarioController(IComentarioService pComentarioService)
        {
            comentarioService = pComentarioService;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var model = comentarioService.GetAll();
            var viewModel = Mapper.Map<List<ComentarioViewModel>>(model);
            return View(viewModel);
        }
        [AllowAnonymous]
        public ActionResult Registrar()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrar(ComentarioViewModel model)
        {
            var comentario = Mapper.Map<Comentario>(model);

            comentario.Opinion = Sanitizer
                    .GetSafeHtmlFragment(comentario.Opinion);

            comentarioService.Guardar(comentario);
            return View();
        }
    }
}