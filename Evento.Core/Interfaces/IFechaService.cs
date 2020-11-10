using Evento.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evento.Core.Interfaces
{
    public interface IFechaService
    {
        IEnumerable<Fecha> GetFechas();

        Task<Fecha> GetFecha(int id);

        Task PostFecha(Fecha o);

        Task<bool> PutFecha(Fecha o);

        Task<bool> DeleteFecha(int id);
    }
}
