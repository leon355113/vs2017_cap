using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Entities.Base;
using App.Data.Repository.Interfaces;
using System.Data.Entity;

namespace App.Data.Repository
{
    public class MarcaRepository:GenericRepository<Marca>,IMarcaRepository
    {

        public MarcaRepository(DbContext context) : base(context)
        {

        }

    }
}
