using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using App.Data.Repository.Interfaces;

namespace App.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext context;

        public GenericRepository(DbContext pContext)
        {
            this.context = pContext;
        }

        public void Add(TEntity entity)
        {
            this.context.Set<TEntity>().Add(entity);
        }

        public int Count()
        {
           return this.context.Set<TEntity>().Count();
        }

        //El include, incluye las tablas que estan relacionadas a la tabla principal

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null , string includes=null )
        {
            var result = new List<TEntity>();
            IQueryable<TEntity> query= this.context.Set<TEntity>();

            //Para tablas relacionadas
            if (includes != null)
            {
                foreach (var tableInclude in includes.Split(','))//foreach para incluir muchas tablas
                {
                   query=  query.Include(tableInclude);
                }
            }

            //Esto es para wheres para filtros
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
             
            return query.ToList();
        }

        public TEntity GetBydId(int id)
        {
            return this.context.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity entity)
        {
            this.context.Set<TEntity>().Attach(entity);
            this.context.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            this.context.Set<TEntity>().Attach(entity);
            this.context.Entry<TEntity>(entity).State = EntityState.Modified;
        }
    }
}
