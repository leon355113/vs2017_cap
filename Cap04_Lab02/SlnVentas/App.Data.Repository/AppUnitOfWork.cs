using App.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public class AppUnitOfWork : IAppUnitOfWork
    {
        private readonly DbContext _context;

        public AppUnitOfWork(DbContext context)
        {
            _context = context;
            this.CategoriaRepository = new CategoriaRepository(_context);
        }

        public ICategoriaRepository CategoriaRepository { get ; set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
