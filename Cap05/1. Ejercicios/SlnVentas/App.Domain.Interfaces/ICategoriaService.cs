using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Interfaces
{
    public interface ICategoriaService
    {
        IEnumerable<Categoria> GetAll(string nombre);

        bool Save(Categoria entity);

        Categoria GetById(int id);
    }
}
