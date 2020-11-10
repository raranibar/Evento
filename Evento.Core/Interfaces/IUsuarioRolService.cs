using Evento.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evento.Core.Interfaces
{
    public interface IUsuarioRolService
    {
        IEnumerable<UsuarioRol> GetUsuarioRoles();

        Task<UsuarioRol> GetUsuarioRol(int id);

        Task PostUsuarioRol(UsuarioRol o);

        Task<bool> PutUsuarioRol(UsuarioRol o);

        Task<bool> DeleteUsuarioRol(int id);
    }
}
