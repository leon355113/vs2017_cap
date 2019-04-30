using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Base
{
    [Table("Usuario")]
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
    }
}
