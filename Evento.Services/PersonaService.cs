using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonaService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Task<Persona> GetPersona(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Persona> GetPersonas()
        {
            throw new NotImplementedException();
        }

        public Task PostPersona(Persona o)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutPersona(Persona o)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeletePersona(int id)
        {
            throw new NotImplementedException();
        }
    }
}
