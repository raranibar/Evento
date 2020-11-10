using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Services
{
    public class ClasificadorService : IClasificadorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClasificadorService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public Task<Clasificador> GetClasificador(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Clasificador> GetClasificadores()
        {
            throw new NotImplementedException();
        }

        public Task PostClasificador(Clasificador o)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutClasificador(Clasificador o)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteClasificador(int id)
        {
            throw new NotImplementedException();
        }

    }
}
