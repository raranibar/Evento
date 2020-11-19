using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evento.Services
{
    public class FotoService : IFotoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FotoService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Foto> GetFoto(int id)
        {
            return await this._unitOfWork.FotoRepository.GetById(id);
        }

        public IEnumerable<Foto> GetFotos()
        {
            return this._unitOfWork.FotoRepository.GetAll().Where(q => q.Estado == true);
        }

        public async Task PostFoto(Foto o)
        {
            await this._unitOfWork.FotoRepository.Add(o);
            await this._unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> PutFoto(Foto o)
        {
            this._unitOfWork.FotoRepository.Update(o);
            await this._unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteFoto(int id)
        {
            await this._unitOfWork.FotoRepository.Delete(id);
            return true;
        }
    }
}
