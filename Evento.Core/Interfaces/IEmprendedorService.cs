using Evento.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evento.Core.Interfaces
{
    public interface IEmprendedorService
    {
        IEnumerable<Emprendedor> GetEmprendedores();

        Task<Emprendedor> GetEmprendedor(int id);

        Task PostEmprendedor(Emprendedor o);

        Task<bool> PutEmprendedor(Emprendedor o);

        Task<bool> DeleteEmprendedor(int id);
    }
}
