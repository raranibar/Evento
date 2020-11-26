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
            throw new NotImplementedException();
        }

        public IEnumerable<Comentario> GetComentarios()
        {
            return this._unitOfWork.ComentarioRepository.GetAll().Where(x => x.Estado == true);
        }

        public async Task PostComentario(Comentario o)
        {
            await this._unitOfWork.ComentarioRepository.Add(o);
            await this._unitOfWork.SaveChangesAsync();
        }

        public Task<bool> PutComentario(Comentario o)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteComentario(int id)
        {
            throw new NotImplementedException();
        }
    }
}
