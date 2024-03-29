﻿using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evento.Services
{
    public class RaitingService : IRaitingService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RaitingService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }        

        public Task<Raiting> GetRaiting(int id)
        {
            return this._unitOfWork.RaitingRepository.GetById(id);
        }

        public IEnumerable<Raiting> GetRaitings()
        {
           return this._unitOfWork.RaitingRepository.GetAll().Where(q=> q.Estado == true);
        }

        public async Task PostRaiting(Raiting o)
        {
            await this._unitOfWork.RaitingRepository.Add(o);
            await this._unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> PutRaiting(Raiting o)
        {
            this._unitOfWork.RaitingRepository.Update(o);
            await this._unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRaiting(int id)
        {
            await this._unitOfWork.RaitingRepository.Delete(id);
            return true;
        }
        public int TotalRaiting()
        {
            return _unitOfWork.RaitingRepository.GetAll().Select(x => x.Rating).Sum();
            
        }

        public decimal RaitingEmprendedor(int Id)
        {
            var total = _unitOfWork.RaitingRepository.GetAll().Select(x => x.Rating).Sum();
            var empre = _unitOfWork.RaitingRepository.GetAll().
                Where(w => w.IdEmprendedor == Id).
                Select(s => s.Rating).Sum();
            return (empre * 100) / total;
        }

        public int VotosEmprendedor(int Id)
        {
            return _unitOfWork.RaitingRepository.GetAll().
                Where(w => w.IdEmprendedor == Id).Count();
        }
    }
}
