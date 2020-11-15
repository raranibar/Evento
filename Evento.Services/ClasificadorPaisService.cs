using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Services
{
    public class ClasificadorPaisService : IClasificadorPaisService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClasificadorPaisService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public Task<bool> DeleteClasificadorPais(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ClasificadorPais> GetClasificadorPais(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClasificadorPais> GetClasificadorPaises()
        {
            throw new NotImplementedException();
        }

        public Task PostClasificadorPais(ClasificadorPais o)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutClasificadorPais(ClasificadorPais o)
        {
            throw new NotImplementedException();
        }
    }
}
