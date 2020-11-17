using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Services
{
    public class CongresoService : ICongresoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CongresoService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public Task<Congreso> GetCongreso(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Congreso> GetCongresos()
        {
            return this._unitOfWork.CongresoRepository.GetAll().Where(q => q.Estado == true); 
        }

        public Task PostCongreso(Congreso o)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> PutCongreso(Congreso o)
        {
            this._unitOfWork.CongresoRepository.Update(o);
            return true;
        }
        public Task<bool> DeleteCongreso(int id)
        {
            throw new NotImplementedException();
        }
    }
}
