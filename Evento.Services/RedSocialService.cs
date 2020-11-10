using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Services
{
    public class RedSocialService : IRedSocialService
    {

        private readonly IUnitOfWork _unitOfWork;
        public RedSocialService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public Task<RedSocial> GetRedSocial(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RedSocial> GetRedSociales()
        {
            throw new NotImplementedException();
        }

        public Task PostRedSocial(RedSocial o)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutRedSocial(RedSocial o)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteRedSocial(int id)
        {
            throw new NotImplementedException();
        }
    }
}
