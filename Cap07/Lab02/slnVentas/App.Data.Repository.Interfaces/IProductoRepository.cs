using App.Entities.Base;
using App.Entities.Queries;
using App.Entities.Queries.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository.Interfaces
{
    public interface IProductoRepository : IGenericRepository<Producto>
    {
        ListaPaginada<ProductoSearch> BuscarProductosStock(ProductoSearchFiltros filtros);
    }
}
