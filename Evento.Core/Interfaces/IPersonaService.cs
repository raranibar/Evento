using Evento.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evento.Core.Interfaces
{
    public interface IPersonaService
    {
        IEnumerable<Persona> GetPersonas();

        Task<Persona> GetPersona(int id);

        Task PostPersona(Persona o);

        Task<bool> PutPersona(Persona o);

        Task<bool> DeletePersona(int id);
    }
}
