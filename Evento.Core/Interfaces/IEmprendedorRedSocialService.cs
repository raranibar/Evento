using Evento.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evento.Core.Interfaces
{
    public interface IEmprendedorRedSocialService
    {
        IEnumerable<EmprendedorRedSocial> GetEmprendedorRedSociales();

        Task<EmprendedorRedSocial> GetEmprendedorRedSocial(int id);

        Task PostEmprendedorRedSocial(EmprendedorRedSocial o);

        Task<bool> PutEmprendedorRedSocial(EmprendedorRedSocial o);

        Task<bool> DeleteEmprendedorRedSocial(int id);
    }
}
