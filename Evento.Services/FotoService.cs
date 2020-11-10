using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Services
{
    public class FotoService : IFotoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FotoService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Task<Foto> GetFoto(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Foto> GetFotos()
        {
            throw new NotImplementedException();
        }

        public Task PostFoto(Foto o)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutFoto(Foto o)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteFoto(int id)
        {
            throw new NotImplementedException();
        }
    }
}
