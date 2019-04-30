using App.Data.Repository;
using App.Domain.Services.Interfaces;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services
{
    public class ComentarioService : IComentarioService
    {
        public IEnumerable<Comentario> GetAll()
        {
            IEnumerable<Comentario> result;
            using (var unitOfWork = new AppUnitOfWork())
            {
                result = unitOfWork.ComentarioRepository.GetAll()
                    .ToList();

            }
            return result;
        }

        public void Guardar(Comentario entity)
        {
            using (var unitOfWork = new AppUnitOfWork())
            {
                unitOfWork.ComentarioRepository.Add(entity);
                unitOfWork.Complete();
            }         
        }


    }
}
