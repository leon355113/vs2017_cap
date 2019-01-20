using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository.Interfaces
{
   public interface IAppUnitOfWork:IDisposable
    {
        ICategoriaRepository CategoriaRepository { get; set; }
        int Complete();
    }
}
