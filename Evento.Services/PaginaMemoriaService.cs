using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Services
{
    public class PaginaMemoriaService : IPaginaMemoriaService
    {

        private readonly IUnitOfWork _unitOfWork;
        public PaginaMemoriaService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public Task<PaginaMemoria> GetPaginaMemoria(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaginaMemoria> GetPaginaMemorias()
        {
            throw new NotImplementedException();
        }

        public Task PostPaginaMemoria(PaginaMemoria o)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutPaginaMemoria(PaginaMemoria o)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeletePaginaMemoria(int id)
        {
            throw new NotImplementedException();
        }
    }
}
