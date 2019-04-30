using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Interfaces
{
    public interface IUnidadMedidaService
    {
        IEnumerable<UnidadMedida> GetAll(string nombre);
        bool Save(UnidadMedida entity);
        UnidadMedida GetById(int id);
    }
}
