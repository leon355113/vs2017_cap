using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cibertect.UI.MVC.Models
{
    public class PersonaViewModel
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string FullName { get; set; }
    }
}