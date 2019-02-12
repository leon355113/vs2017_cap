using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity:class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        TEntity GetBydId(int id);
        IEnumerable<TEntity> GetAll(
            Expression<Func<TEntity,bool>> predicate=null, string includes = null);//Se coloca null porque es un parametro opcional


        //IEnumerable<TEntity> GetAll(
        //   Expression<Func<TEntity, bool>> predicate = null, List<string> includes = null);//Se coloca null porque es un parametro opcional
        int Count();

    }
}
