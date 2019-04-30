using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cibertect.UI.MVC.Models;

namespace Cibertect.UI.MVC.Controllers
{
    public class RegistroController : Controller
    {
        
        [HttpPost]
        public JsonResult Registro(PersonaViewModel persona)
        {
            persona.FullName = persona.Nombres + " " + persona.Apellidos;

            return Json(persona);
        }
    }
}