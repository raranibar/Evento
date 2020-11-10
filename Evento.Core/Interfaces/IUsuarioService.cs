using Evento.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evento.Core.Interfaces
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> GetUsuarios();

        Task<Usuario> GetUsuario(int id);

        Task PostUsuario(Usuario o);

        Task<bool> PutUsuario(Usuario o);

        Task<bool> DeleteUsuario(int id);
    }
}
