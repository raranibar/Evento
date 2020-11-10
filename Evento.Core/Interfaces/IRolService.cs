using Evento.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evento.Core.Interfaces
{
    public interface IRolService
    {
        IEnumerable<Rol> GetRoles();

        Task<Rol> GetRol(int id);

        Task PostRol(Rol o);

        Task<bool> PutRol(Rol o);

        Task<bool> DeleteRol(int id);
    }
}
