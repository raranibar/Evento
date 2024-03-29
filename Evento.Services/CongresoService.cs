﻿using Evento.Core.Entities;
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
            return this._unitOfWork.CongresoRepository.GetById(id);
        }

        public IEnumerable<Congreso> GetCongresos()
        {
            return this._unitOfWork.CongresoRepository.GetAll().Where(q => q.Estado == true);
        }

        public async Task PostCongreso(Congreso o)
        {
            await this._unitOfWork.CongresoRepository.Add(o);
            await this._unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> PutCongreso(Congreso o)
        {
            this._unitOfWork.CongresoRepository.Update(o);
            await this._unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteCongreso(int id)
        {
            await this._unitOfWork.CongresoRepository.Delete(id);
            return true;
        }
    }
}
