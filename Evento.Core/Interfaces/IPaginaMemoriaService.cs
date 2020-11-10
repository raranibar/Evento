using Evento.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evento.Core.Interfaces
{
    public interface IPaginaMemoriaService
    {
        IEnumerable<PaginaMemoria> GetPaginaMemorias();

        Task<PaginaMemoria> GetPaginaMemoria(int id);

        Task PostPaginaMemoria(PaginaMemoria o);

        Task<bool> PutPaginaMemoria(PaginaMemoria o);

        Task<bool> DeletePaginaMemoria(int id);
    }
}
