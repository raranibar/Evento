using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Services
{
    public class vProgramaEjeTematicoService : IvProgramaEjeTematicoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public vProgramaEjeTematicoService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public Task<vProgramaEjeTematico> GetvPProgramaEjeTematico(int id)
        {
            return this._unitOfWork.vProgramaEjeTematicoRepository.GetById(id);
        }

        public IEnumerable<vProgramaEjeTematico> GetvProgramaEjeTematicos()
        {
            return this._unitOfWork.vProgramaEjeTematicoRepository.GetAll();
        }
    }
}
