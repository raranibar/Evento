using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Services
{
    public class ComentarioService : IComentarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ComentarioService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public Task<Comentario> GetComentario(int id)
        {
            return this._unitOfWork.ComentarioRepository.GetById(id);
        }

        public IEnumerable<Comentario> GetComentarios()
        {
            return this._unitOfWork.ComentarioRepository.GetAll().Where(q => q.Estado == true);
        }

        public async Task PostComentario(Comentario o)
        {
            await this._unitOfWork.ComentarioRepository.Add(o);
            await this._unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> PutComentario(Comentario o)
        {
            this._unitOfWork.ComentarioRepository.Update(o);
            await this._unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteComentario(int id)
        {
            await this._unitOfWork.ComentarioRepository.Delete(id);
            await this._unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
