using Evento.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evento.Core.Interfaces
{
    public interface IDetalleClasificadorService
    {
        IEnumerable<DetalleClasificador> GetDetalleClasificadores();

        Task<DetalleClasificador> GetDetalleClasificador(int id);

        Task PostDetalleClasificador(DetalleClasificador o);

        Task<bool> PutDetalleClasificador(DetalleClasificador o);

        Task<bool> DeleteDetalleClasificador(int id);
    }
}
