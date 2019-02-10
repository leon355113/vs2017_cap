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
    public class ProductoService : IProductoService
    {
        public IEnumerable<Producto> GetAll(string nombre, int? categoriaID)
        {
            List<Producto> results;
            //var includes = new List<string>();
            //includes.Add("Categoria");
            //includes.Add("Marca");

            using (var unitOfWork = new AppUnitOfWork())
            {
                results = unitOfWork.ProductoRepository.GetAll(
                    item => item.Nombre.Contains(nombre) && (categoriaID == null || item.CategoriaID == categoriaID), "Categoria,Marca"
                    ).ToList();
            }
            return results;
        }

        public Producto GetById(int id)
        {
            Producto results;
            //var includes = new List<string>();
            //includes.Add("Categoria");
            //includes.Add("Marca");

            using (var unitOfWork = new AppUnitOfWork())
            {
                results = unitOfWork.ProductoRepository.GetById(id);     
            }
            return results;
        }

        public bool Save(Producto entity)
        {
            bool result = false;

            try
            {
                using (var unitofwork = new AppUnitOfWork())
                {
                    if(entity.ProductoID==0)
                    {
                        unitofwork.ProductoRepository.Add(entity);
                    }
                    else
                    {
                        unitofwork.ProductoRepository.Update(entity);
                    }

                    unitofwork.Complete();
                }

                result = true;
            }
            catch(Exception ex)
            {
                result = false;
            }

            return result;
        }



    }
}
