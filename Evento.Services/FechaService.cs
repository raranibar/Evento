using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Services
{
    public class FechaService : IFechaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FechaService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Task<Fecha> GetFecha(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Fecha> GetFechas()
        {
            throw new NotImplementedException();
        }

        public Task PostFecha(Fecha o)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutFecha(Fecha o)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteFecha(int id)
        {
            throw new NotImplementedException();
        }
    }
}
