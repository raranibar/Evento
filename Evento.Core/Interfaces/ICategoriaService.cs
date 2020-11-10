using Evento.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evento.Core.Interfaces
{
    public interface ICategoriaService
    {
        IEnumerable<Categoria> GetCategorias();

        Task<Categoria> GetCategoria(int id);

        Task PostCategoria(Categoria o);

        Task<bool> PutCategoria(Categoria o);

        Task<bool> DeleteCategoria(int id);
    }
}
