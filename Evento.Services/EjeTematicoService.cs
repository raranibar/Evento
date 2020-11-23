using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Services
{
    public class EjeTematicoService : IEjeTematicoService
    {

        private readonly IUnitOfWork _unitOfWork;
        public EjeTematicoService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public Task<EjeTematico> GetEjeTematico(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EjeTematico> GetEjeTematicos()
        {
            return this._unitOfWork.EjeTematicoRepository.GetAll().Where(x => x.Estado == true);

        }

        public Task PostEjeTematico(EjeTematico o)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutEjeTematico(EjeTematico o)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteEjeTematico(int id)
        {
            throw new NotImplementedException();
        }
    }
}
