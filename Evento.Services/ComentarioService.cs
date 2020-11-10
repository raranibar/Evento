using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public Task PostComentario(Comentario o)
        {
            throw new NotImplementedException();
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
