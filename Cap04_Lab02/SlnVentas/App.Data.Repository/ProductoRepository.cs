using App.Data.Repository.Interfaces;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository
{
   public class ProductoRepository:GenericRepository<Producto>, IProductoRepository
    {
        public ProductoRepository(DbContext context):base(context)
        {

        }
    }
}
