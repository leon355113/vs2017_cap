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
    public class MarcaService : IMarcaService
    {
       public  IEnumerable<Marca> GetAll(string nombre)
        {
            List<Marca> results;
            using(var unitofwork=new AppUnitOfWork())
            {
                results = unitofwork.MarcaRepository.GetAll(
                    item => item.Nombre.Contains(nombre)).ToList();
            }
            return results;
        }

        public Marca getById(int id)
        {
            Marca result;
            using(var unitofwork=new AppUnitOfWork())
            {
                result = unitofwork.MarcaRepository.GetBydId(id);
            }
            return result;
        }

        public bool Save(Marca entity)
        {
            bool result = false;

            try
            {
                using (var unitofwork = new AppUnitOfWork())
                {
                    if (entity.MarcaID == 0)
                    {
                        unitofwork.MarcaRepository.Add(entity);
                    }
                    else
                    {
                        unitofwork.MarcaRepository.Update(entity);
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
