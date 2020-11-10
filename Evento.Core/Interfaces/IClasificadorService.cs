using Evento.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evento.Core.Interfaces
{
    public interface IClasificadorService
    {
        IEnumerable<Clasificador> GetClasificadores();

        Task<Clasificador> GetClasificador(int id);

        Task PostClasificador(Clasificador o);

        Task<bool> PutClasificador(Clasificador o);

        Task<bool> DeleteClasificador(int id);
    }
}
