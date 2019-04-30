using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Queries
{
    public class ProductoSearch
    {
        public int ProductoID { get; set; }

        public string ProductoCode { get; set; }

        public string Nombre { get; set; }

        public string CategoriaName { get; set; }

        public string MarcaName { get; set; }

        public decimal PrecioMayor { get; set; }

        public decimal PrecioMenor { get; set; }

        public decimal StockActual { get; set; }
    }
}
