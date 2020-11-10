using Evento.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Core.Interfaces
{
    public interface ICongresoUsuarioService
    {
        IEnumerable<CongresoUsuario> GetCongresoUsuarios();

        Task<CongresoUsuario> GetCongresoUsuario(int id);

        Task PostCongresoUsuario(CongresoUsuario o);

        Task<bool> PutCongresoUsuario(CongresoUsuario o);

        Task<bool> DeleteCongresoUsuario(int id);
    }
}
