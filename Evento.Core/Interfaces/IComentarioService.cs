using Evento.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evento.Core.Interfaces
{
    public interface IComentarioService
    {
        IEnumerable<Comentario> GetComentarios();

        Task<Comentario> GetComentario(int id);

        Task PostComentario(Comentario o);

        Task<bool> PutComentario(Comentario o);

        Task<bool> DeleteComentario(int id);
    }
}
