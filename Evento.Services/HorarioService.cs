using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Services
{
    public class HorarioService : IHorarioService
    {

        private readonly IUnitOfWork _unitOfWork;
        public HorarioService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public Task<Horario> GetHorario(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Horario> GetHorarios()
        {
            throw new NotImplementedException();
        }

        public Task PostHorario(Horario o)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutHorario(Horario o)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteHorario(int id)
        {
            throw new NotImplementedException();
        }
    }
}
