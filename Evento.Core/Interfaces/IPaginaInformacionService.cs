using Evento.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evento.Core.Interfaces
{
    public interface IPaginaInformacionService
    {
        IEnumerable<PaginaInformacion> GetPaginaInformaciones();

        Task<PaginaInformacion> GetPaginaInformacion(int id);

        Task PostPaginaInformacion(PaginaInformacion o);

        Task<bool> PutPaginaInformacion(PaginaInformacion o);

        Task<bool> DeletePaginaInformacion(int id);
    }
}
