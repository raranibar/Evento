using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Services
{
    public class EmprendedorService : IEmprendedorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmprendedorService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Task<Emprendedor> GetEmprendedor(int id)
        {
            return this._unitOfWork.EmprendedorRepository.GetById(id);

        }

        public IEnumerable<Emprendedor> GetEmprendedores()
        {
            throw new NotImplementedException();
        }

        public async Task  PostEmprendedor(Emprendedor o)
        {
            await this._unitOfWork.EmprendedorRepository.Add(o);
            await this._unitOfWork.SaveChangesAsync();
        }

        public Task<bool> PutEmprendedor(Emprendedor o)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteEmprendedor(int id)
        {
            throw new NotImplementedException();
        }
    }
}
