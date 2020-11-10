using Evento.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evento.Core.Interfaces
{
    public interface IHorarioService
    {
        IEnumerable<Horario> GetHorarios();

        Task<Horario> GetHorario(int id);

        Task PostHorario(Horario o);

        Task<bool> PutHorario(Horario o);

        Task<bool> DeleteHorario(int id);
    }
}
