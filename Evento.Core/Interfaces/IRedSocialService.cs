using Evento.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evento.Core.Interfaces
{
    public interface IRedSocialService
    {
        IEnumerable<RedSocial> GetRedSociales();

        Task<RedSocial> GetRedSocial(int id);

        Task PostRedSocial(RedSocial o);

        Task<bool> PutRedSocial(RedSocial o);

        Task<bool> DeleteRedSocial(int id);
    }
}
