using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Services
{
    public class CongresoUsuarioService : ICongresoUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CongresoUsuarioService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public Task<CongresoUsuario> GetCongresoUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CongresoUsuario> GetCongresoUsuarios()
        {
            throw new NotImplementedException();
        }

        public async Task PostCongresoUsuario(CongresoUsuario o)
        {
            await this._unitOfWork.CongresoUsuarioRepository.Add(o);
            await this._unitOfWork.SaveChangesAsync();
        }

        public Task<bool> PutCongresoUsuario(CongresoUsuario o)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteCongresoUsuario(int id)
        {
            throw new NotImplementedException();
        }
    }
}
