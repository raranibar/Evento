using Evento.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evento.Core.Interfaces
{
    public interface IEjeTematicoService
    {
        IEnumerable<EjeTematico> GetEjeTematicos();

        Task<EjeTematico> GetEjeTematico(int id);

        Task PostEjeTematico(EjeTematico o);

        Task<bool> PutEjeTematico(EjeTematico o);

        Task<bool> DeleteEjeTematico(int id);
    }
}
