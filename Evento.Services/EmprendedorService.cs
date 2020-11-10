using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Services
{
    public class EmprendedorService : IEmprendedorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmprendedorService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Task<Emprendedor> GetEmprendedor(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Emprendedor> GetEmprendedores()
        {
            throw new NotImplementedException();
        }

        public Task PostEmprendedor(Emprendedor o)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutEmprendedor(Emprendedor o)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteEmprendedor(int id)
        {
            throw new NotImplementedException();
        }
    }
}
