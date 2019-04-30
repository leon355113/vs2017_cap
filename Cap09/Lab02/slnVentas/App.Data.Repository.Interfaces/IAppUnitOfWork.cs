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
        IProductoRepository ProductoRepository { get; set; }
        IMarcaRepository MarcaRepository { get; set; }
        IUnidadMedidaRepository UnidadMedidaRepository { get; set; }
        IUsuarioRepository UsuarioRepository { get; set; }
        IComentarioRepository ComentarioRepository { get; set; }
        int Complete();

    }
}
