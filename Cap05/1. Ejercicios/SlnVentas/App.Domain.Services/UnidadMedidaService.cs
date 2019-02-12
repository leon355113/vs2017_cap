using App.Data.Repository;
using App.Domain.Interfaces;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services
{
    public class UnidadMedidaService : IUnidadMedidaService
    {
        public IEnumerable<UnidadMedida> GetAll(string nombre)
        {
            List<UnidadMedida> results;
            using (var unitOfWork = new AppUnitOfWork())
            {
                results = unitOfWork.UnidadMedidaRepository.GetAll(
                    item => item.Nombre.Contains(nombre)
                    ).ToList();
            }
            return results;
        }

        public UnidadMedida GetById(int id)
        {
            UnidadMedida results;
            using (var unitOfWork = new AppUnitOfWork())
            {
                results = unitOfWork.UnidadMedidaRepository.GetBydId(id);
            }
            return results;
        }

        public bool Save(UnidadMedida entity)
        {
            bool result = false;
            try
            {
                using (var unitOfWork = new AppUnitOfWork())
                {
                    if (entity.UnidadMedidaID == 0)//Cuando es nuevo regiatro
                    {
                        unitOfWork.UnidadMedidaRepository.Add(entity);

                    }
                    else
                    {
                        unitOfWork.UnidadMedidaRepository.Update(entity);

                    }
                    unitOfWork.Complete();
                }

                result = true;
            }
            catch (Exception ex)
            {

                result = false;
            }

            return result;
        }
    }
}
