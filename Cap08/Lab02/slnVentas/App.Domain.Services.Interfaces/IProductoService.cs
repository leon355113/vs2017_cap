using App.Entities.Base;
using App.Entities.Queries;
using App.Entities.Queries.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Interfaces
{
    public interface IProductoService
    {
        IEnumerable<Producto> GetAll(string nombre, int? categoriaID);

        ListaPaginada<ProductoSearch> BuscarProductosStock(ProductoSearchFiltros filtros);
    }
}
