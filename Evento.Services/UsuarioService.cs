using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsuarioService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Task<Usuario> GetUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            throw new NotImplementedException();
        }

        public Task PostUsuario(Usuario o)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutUsuario(Usuario o)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteUsuario(int id)
        {
            throw new NotImplementedException();
        }
    }
}
