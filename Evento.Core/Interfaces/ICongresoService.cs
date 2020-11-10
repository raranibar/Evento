using Evento.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evento.Core.Interfaces
{
    public interface ICongresoService
    {
        IEnumerable<Congreso> GetCongresos();

        Task<Congreso> GetCongreso(int id);

        Task PostCongreso(Congreso o);

        Task<bool> PutCongreso(Congreso o);

        Task<bool> DeleteCongreso(int id);
    }
}
