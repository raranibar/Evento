using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Services
{
    public class ClasificadorCiudadService : IClasificadorCiudadService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClasificadorCiudadService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public Task<bool> DeleteClasificadorCiudad(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ClasificadorCiudad> GetClasificadorCiudad(int id)
        {
            return this._unitOfWork.ClasificadorCiudadRepository.GetById(id);
        }

        public IEnumerable<ClasificadorCiudad> GetClasificadorCiudades()
        {
            return this._unitOfWork.ClasificadorCiudadRepository.GetAll();

        }

        public Task PostClasificadorCiudad(ClasificadorCiudad o)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutClasificadorCiudad(ClasificadorCiudad o)
        {
            throw new NotImplementedException();
        }
    }
}
