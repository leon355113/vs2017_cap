using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Entities.Base;

namespace App.Domain.Interfaces
{
   public interface IMarcaService
    {
        IEnumerable<Marca> GetAll(string nombre);
        bool Save(Marca entity);
        Marca GetById(int id);
    }
}
