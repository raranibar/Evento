using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Services
{
    public class PaginaInformacionService : IPaginaInformacionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PaginaInformacionService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Task<PaginaInformacion> GetPaginaInformacion(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaginaInformacion> GetPaginaInformaciones()
        {
            throw new NotImplementedException();
        }

        public Task PostPaginaInformacion(PaginaInformacion o)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutPaginaInformacion(PaginaInformacion o)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeletePaginaInformacion(int id)
        {
            throw new NotImplementedException();
        }
    }
}
