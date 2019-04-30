using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Interfaces
{
    public interface IComentarioService
    {
        void Guardar(Comentario entity);

        IEnumerable<Comentario> GetAll();
    }
}
