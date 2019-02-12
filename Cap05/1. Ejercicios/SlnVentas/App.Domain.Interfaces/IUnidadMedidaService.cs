using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Entities.Base;

namespace App.Domain.Interfaces
{
   public interface IUnidadMedidaService
    {
        IEnumerable<UnidadMedida> GetAll(string nombre);
        bool Save(UnidadMedida entity);
        UnidadMedida GetById(int id);
    }
}
