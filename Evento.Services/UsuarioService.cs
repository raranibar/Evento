using Evento.Core.DTO;
using Evento.Core.Entities;
using Evento.Core.Helper;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return this._unitOfWork.UsuarioRepository.GetById(id);
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            return this._unitOfWork.UsuarioRepository.GetAll().Where(x=>x.Estado==true);
        }

        public async Task PostUsuario(Usuario o)
        {
            string passwordSalt = PasswordHasher.GenerateSalt();
            string hashedPassword = PasswordHasher.GenerateHash(o.Clave, passwordSalt);
            o.Clave = hashedPassword;
            o.ClaveSalt = passwordSalt;
            await this._unitOfWork.UsuarioRepository.Add(o);
            await this._unitOfWork.SaveChangesAsync();
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
