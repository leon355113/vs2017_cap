using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data.Repository;
using App.Domain.Interfaces;
using App.Entities.Base;

namespace App.Domain.Services
{
    public class UnidadMedidaService : IUnidadMedidaService
    {
        public IEnumerable<UnidadMedida> GetAll(string Nombre)
        {
            List<UnidadMedida> result;
            using(var unitofwork=new AppUnitOfWork())
            {
                result = unitofwork.UnidadMedidaRepository.GetAll(
                    item => item.Nombre.Contains(Nombre)
                    ).ToList();
            }

            return result;
        }

        public UnidadMedida GetById(int id)
        {
            UnidadMedida result;
            using(var unitofwork=new AppUnitOfWork())
            {
                result = unitofwork.UnidadMedidaRepository.GetBydId(id);
            }
            return result;
        }

        public bool Save(UnidadMedida entity)
        {
            bool result = false;
            try
            {
                using (var unitofwork = new AppUnitOfWork())
                {
                    if (entity.UnidadMedidaID == 0)
                    {
                        unitofwork.UnidadMedidaRepository.Add(entity);
                    }
                    else
                    {
                        unitofwork.UnidadMedidaRepository.Update(entity);
                    }
                    unitofwork.Complete();
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
