using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace App.UI.Web.MVC.Common
{
    public static class SecurityHelpers
    {
        public static List<Claim> CreateClaimsUsuario(Usuario usuario)
        {
            var claims = new List<Claim>();
            //Creando pedazos de información para que se guarden en la Cookie de Seguridad
            claims.Add(new Claim(ClaimTypes.Name, $"{usuario.Nombres} {usuario.Apellidos}"));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, usuario.Login));
            claims.Add(new Claim(ClaimTypes.Email, usuario.Email));
            claims.Add(new Claim("UsuarioID", usuario.UsuarioID.ToString()));

            //Creando claims de roles para ser utilizados en conjunto
            //con el atributo Authorize de MVC
            string[] roles = null;
            roles = usuario.Roles.Split(';');
            foreach (string rol in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, rol));
            }

            return claims;
        }

        public static IEnumerable<Claim> GetClaimsByType(string type)
        {
            var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
            var claims = identity.Claims.Where(item => item.Type == type).ToList();
            return claims;
        }

        public static string GetUserFullName()
        {
            var claimValue = GetClaimsByType(ClaimTypes.Name).FirstOrDefault()?.Value;
            return claimValue;
        }

        public static int GetUsuarioID()
        {
            var claimValue = GetClaimsByType("UsuarioID").FirstOrDefault() != null ?
                            Convert.ToInt32(GetClaimsByType("UsuarioID").FirstOrDefault().Value) : 0;
            return claimValue;
        }

        public static bool IsLogged()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }

        public static bool IsAdmin()
        {
            return HttpContext.Current.User.IsInRole("Admin");
        }

        /*
         Algoritomo de encriptamiento PBKDF2
         string password = "123456";
            using (var deriveBytes = new Rfc2898DeriveBytes(password,20))
            {
                byte[] salt = deriveBytes.Salt;
                byte[] key = deriveBytes.GetBytes(20);

                string encodeSalt = Convert.ToBase64String(salt);
                string encodeKey = Convert.ToBase64String(key);


            }
            //Database
            string encodeSaltDB = "Gn+1jeMaDob22KSfCQ2K/ihckCo=";
            string encodeKeyDB = "vbUAWLs7NXMJO0ibjjDrEtYSsnU=";

            byte[] saltDB = Convert.FromBase64String(encodeSaltDB);
            byte[] keyDB = Convert.FromBase64String(encodeKeyDB);

            string passwordLogin = "123456";
            using (var deriveBytes = new Rfc2898DeriveBytes(passwordLogin, saltDB))
            {
                byte[] testKey = deriveBytes.GetBytes(20);
                if(testKey.SequenceEqual(keyDB))
                {
                    MessageBox.Show("Password Valido");
                }

            }
         */
    }
}