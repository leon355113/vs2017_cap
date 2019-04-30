    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Queries.Filtros
{
    public class ProductoSearchFiltros
    {
        public string Nombre { get; set; }
        public decimal Stock { get; set; }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }

    }
}
