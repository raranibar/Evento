using Evento.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Core.Interfaces
{
    public interface IClasificadorCiudadService
    {
        IEnumerable<ClasificadorCiudad> GetClasificadorCiudades();

        Task<ClasificadorCiudad> GetClasificadorCiudad(int id);

        Task PostClasificadorCiudad(ClasificadorCiudad o);

        Task<bool> PutClasificadorCiudad(ClasificadorCiudad o);

        Task<bool> DeleteClasificadorCiudad(int id);
    }
}
