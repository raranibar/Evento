using Evento.Core.DTO;
using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Expositor> GetExpositor(int id)
        {
            return await this._unitOfWork.ExpositorRepository.GetById(id);
        }

        public IEnumerable<Expositor> GetExpositores()
        {
            return this._unitOfWork.ExpositorRepository.GetAll().Where(x => x.Estado == true);
        }

        public async Task PostExpositor(Expositor o)
        {
            await this._unitOfWork.ExpositorRepository.Add(o);
            await this._unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> PutExpositor(Expositor o)
        {
            this._unitOfWork.ExpositorRepository.Update(o);
            await this._unitOfWork.SaveChangesAsync();
            return true;
        }

        public Task<bool> DeleteExpositor(int id)
        {
            throw new NotImplementedException();
        }
    }
}
