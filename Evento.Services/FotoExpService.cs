using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Services
{
    public class FotoExpService : IFotoExpService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FotoExpService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<FotoExp> GetFotoExp(int id)
        {
            return await this._unitOfWork.FotoExpRepository.GetById(id);
        }

        public IEnumerable<FotoExp> GetFotosExp()
        {
            return this._unitOfWork.FotoExpRepository.GetAll().Where(q => q.Estado == true);
        }

        public async Task PostFotoExp(FotoExp o)
        {
            await this._unitOfWork.FotoExpRepository.Add(o);
            await this._unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> PutFotoExp(FotoExp o)
        {
            this._unitOfWork.FotoExpRepository.Update(o);
            await this._unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteFotoExp(int id)
        {
            await this._unitOfWork.FotoExpRepository.Delete(id);
            return true;
        }
    }
}
