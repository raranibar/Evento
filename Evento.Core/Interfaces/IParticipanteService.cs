using Evento.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evento.Core.Interfaces
{
    public interface IParticipanteService
    {
        IEnumerable<Participante> GetParticipantes();

        Task<Participante> GetParticipante(int id);

        Task PostParticipante(Participante o);

        Task<bool> PutParticipante(Participante o);

        Task<bool> DeleteParticipante(int id);
    }
}
