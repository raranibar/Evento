using Evento.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evento.Core.Interfaces
{
    public interface IFotoService
    {
        IEnumerable<Foto> GetFotos();

        Task<Foto> GetFoto(int id);

        Task PostFoto(Foto o);

        Task<bool> PutFoto(Foto o);

        Task<bool> DeleteFoto(int id);
    }
}
