using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Services
{
    public class UsuarioRolService : IUsuarioRolService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsuarioRolService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Task<UsuarioRol> GetUsuarioRol(int id)
        {
            return _unitOfWork.UsuarioRolRepository.GetById(id);
        }

        public IEnumerable<UsuarioRol> GetUsuarioRoles()
        {
            return _unitOfWork.UsuarioRolRepository.GetAll().Where(x=>x.Estado==true);
        }

        public async Task PostUsuarioRol(UsuarioRol o)
        {
            await this._unitOfWork.UsuarioRolRepository.Add(o);
            await this._unitOfWork.SaveChangesAsync();
        }

        public Task<bool> PutUsuarioRol(UsuarioRol o)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteUsuarioRol(int id)
        {
            throw new NotImplementedException();
        }
    }
}
