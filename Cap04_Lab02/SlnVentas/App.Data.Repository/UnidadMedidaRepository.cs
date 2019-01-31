using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Entities.Base;
using System.Data.Entity;
using App.Data.Repository.Interfaces;

namespace App.Data.Repository
{
    public class UnidadMedidaRepository:GenericRepository<UnidadMedida>,IUnidadMedidaRepository
    {
        public UnidadMedidaRepository(DbContext context):base(context)
        {

        }

    }
}
