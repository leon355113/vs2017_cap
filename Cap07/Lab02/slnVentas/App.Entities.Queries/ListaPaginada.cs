using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Queries
{
    public class ListaPaginada<T>
        where T:class
    {
        public List<T> Listado { get; set; }
        public int TotalRows { get; set; }

    }
}
