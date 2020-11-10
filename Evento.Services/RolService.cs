using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Services
{
    public class RolService : IRolService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RolService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public Task<Rol> GetRol(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rol> GetRoles()
        {
            return _unitOfWork.RolRepository.GetAll().Where(q => q.Estado == true);
        }

        public Task PostRol(Rol o)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutRol(Rol o)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteRol(int id)
        {
            throw new NotImplementedException();
        }

    }
}
