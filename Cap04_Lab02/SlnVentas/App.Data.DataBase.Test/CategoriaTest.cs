using System;
using App.Entities.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace App.Data.DataBase.Test
{
    [TestClass]
    public class CategoriaTest
    {
        [TestMethod]
        public void NuevaCategoria()
        {
            using (var model = new AppModel())
            {
                var categoria = new Categoria()
                {
                    Nombre = "Mouse",
                    Estado = true
                };

                model.Categoria.Add(categoria);
                model.SaveChanges(); //Es requerido para confirmar 
                                    //la transaccion en EF

                //Verificando que se este creando la categoria
                Assert.IsTrue(categoria.CategoriaID > 0);
            }
        }

        [TestMethod]
        public void VerificarRegistos()
        {
            using (var model = new AppModel())
            {
                var cantidad = model.Categoria.Count();

                Assert.IsTrue(cantidad > 0);
            }
        }
    }
}
