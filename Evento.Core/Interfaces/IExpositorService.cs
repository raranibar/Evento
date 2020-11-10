using Evento.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evento.Core.Interfaces
{
    public interface IExpositorService
    {
        IEnumerable<Expositor> GetExpositores();

        Task<Expositor> GetExpositor(int id);

        Task PostExpositor(Expositor o);

        Task<bool> PutExpositor(Expositor o);

        Task<bool> DeleteExpositor(int id);
    }
}
