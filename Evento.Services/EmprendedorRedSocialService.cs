using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Services
{
    public class EmprendedorRedSocialService : IEmprendedorRedSocialService
    {

        private readonly IUnitOfWork _unitOfWork;
        public EmprendedorRedSocialService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public Task<EmprendedorRedSocial> GetEmprendedorRedSocial(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmprendedorRedSocial> GetEmprendedorRedSociales()
        {
            throw new NotImplementedException();
        }

        public Task PostEmprendedorRedSocial(EmprendedorRedSocial o)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutEmprendedorRedSocial(EmprendedorRedSocial o)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteEmprendedorRedSocial(int id)
        {
            throw new NotImplementedException();
        }
    }
}
