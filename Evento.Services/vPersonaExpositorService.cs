using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Services
{
    public class vPersonaExpositorService : IvPersonaExpositorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public vPersonaExpositorService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Task<vPersonaExpositor> GetvPersonaExpositor(int id)
        {
            return this._unitOfWork.vPersonaExpositorRepository.GetById(id);
        }

        public IEnumerable<vPersonaExpositor> GevPersonaExpositors()
        {
            return this._unitOfWork.vPersonaExpositorRepository.GetAll();
        }
    }
}
