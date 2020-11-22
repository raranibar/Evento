using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Services
{
    public class EmprendedorRedSocialService : IEmprendedorRedSocialService
    {

        private readonly IUnitOfWork _unitOfWork;
        public EmprendedorRedSocialService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public Task<EmprendedorRedSocial> GetEmprendedorRedSocial(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmprendedorRedSocial> GetEmprendedorRedSociales()
        {
            return this._unitOfWork.EmprendedorRedSocialRepository.GetAll().Where(x=>x.Estado==true);
        }

        public async Task PostEmprendedorRedSocial(EmprendedorRedSocial o)
        {
            await this._unitOfWork.EmprendedorRedSocialRepository.Add(o);
            await this._unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> PutEmprendedorRedSocial(EmprendedorRedSocial o)
        {
            this._unitOfWork.EmprendedorRedSocialRepository.Update(o);
            await this._unitOfWork.SaveChangesAsync();
            return true;
        }
        public Task<bool> DeleteEmprendedorRedSocial(int id)
        {
            throw new NotImplementedException();
        }
    }
}
