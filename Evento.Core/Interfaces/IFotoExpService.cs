using Evento.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Core.Interfaces
{
    public interface IFotoExpService
    {
        IEnumerable<FotoExp> GetFotosExp();

        Task<FotoExp> GetFotoExp(int id);

        Task PostFotoExp(FotoExp o);

        Task<bool> PutFotoExp(FotoExp o);

        Task<bool> DeleteFotoExp(int id);
    }
}
