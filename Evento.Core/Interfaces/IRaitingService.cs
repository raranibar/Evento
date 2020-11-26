using Evento.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Core.Interfaces
{
    public interface IRaitingService
    {
        IEnumerable<Raiting> GetRaitings();

        Task<Raiting> GetRaiting(int id);

        Task PostRaiting(Raiting o);

        Task<bool> PutRaiting(Raiting o);

        Task<bool> DeleteRaiting(int id);

        int TotalRaiting();
        decimal RaitingEmprendedor(int Id);
        int VotosEmprendedor(int Id);
    }
}
