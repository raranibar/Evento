using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Services
{
    public class ExpositorService : IExpositorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ExpositorService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Task<Expositor> GetExpositor(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Expositor> GetExpositores()
        {
            throw new NotImplementedException();
        }

        public Task PostExpositor(Expositor o)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutExpositor(Expositor o)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteExpositor(int id)
        {
            throw new NotImplementedException();
        }
    }
}
