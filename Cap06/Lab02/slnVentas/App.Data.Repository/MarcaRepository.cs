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
    public class MarcaRepository:GenericRepository<Marca>, IMarcaRepository
    {
        public MarcaRepository(DbContext context):base(context)
        {

        }
    }
}
