using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Interfaces
{
    public interface IProductoService
    {
        IEnumerable<Producto> GetAll(string nombre, int? categoriaID, int? marcaID);

        bool Save(Producto entity);

        Producto GetById(int id);
    }
}
