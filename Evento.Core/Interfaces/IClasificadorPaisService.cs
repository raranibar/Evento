using Evento.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Core.Interfaces
{
    public interface IClasificadorPaisService
    {
        IEnumerable<ClasificadorPais> GetClasificadorPaises();

        Task<ClasificadorPais> GetClasificadorPais(int id);

        Task PostClasificadorPais(ClasificadorPais o);

        Task<bool> PutClasificadorPais(ClasificadorPais o);

        Task<bool> DeleteClasificadorPais(int id);
    }
}
