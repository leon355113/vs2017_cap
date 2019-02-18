using App.Data.Repository;
using App.Domain.Services.Interfaces;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services
{
    public class ProductoService : IProductoService
    {
        public IEnumerable<Producto> GetAll(string nombre, int? categoriaID)
        {
            List<Producto> results;

            using (var unitOfWork = new AppUnitOfWork())
            {
                results = unitOfWork.ProductoRepository
                    .GetAll(
                    item=>item.Nombre.Contains(nombre) && (categoriaID ==null || categoriaID == 0 || item.CategoriaID==categoriaID),"Categoria,Marca"
                    ).ToList();
                
            }

            return results;
        }

    }
}
