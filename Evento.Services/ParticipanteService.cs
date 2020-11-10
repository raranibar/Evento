using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Services
{
    public class ParticipanteService : IParticipanteService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ParticipanteService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Task<Participante> GetParticipante(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Participante> GetParticipantes()
        {
            throw new NotImplementedException();
        }

        public Task PostParticipante(Participante o)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutParticipante(Participante o)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteParticipante(int id)
        {
            throw new NotImplementedException();
        }
    }
}
