using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return this._unitOfWork.EmprendedorRepository.GetAll();
        }

        public async Task  PostEmprendedor(Emprendedor o)
        {
            await this._unitOfWork.EmprendedorRepository.Add(o);
            await this._unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> PutEmprendedor(Emprendedor o)
        {
            this._unitOfWork.EmprendedorRepository.Update(o);
            await this._unitOfWork.SaveChangesAsync();
            return true;
        }
        public Task<bool> DeleteEmprendedor(int id)
        {
            throw new NotImplementedException();
        }
    }
}
