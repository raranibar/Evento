﻿using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return this._unitOfWork.RedSocialRepository.GetById(id);

        }

        public IEnumerable<RedSocial> GetRedSociales()
        {
            return this._unitOfWork.RedSocialRepository.GetAll();
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
