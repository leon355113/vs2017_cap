using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Models.ViewModels
{
    public class ComentarioViewModel
    {
        public int ComentarioID { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        [AllowHtml]
        public string Opinion { get; set; }
    }
}