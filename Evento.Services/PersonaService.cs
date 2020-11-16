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
            return this._unitOfWork.PersonaRepository.GetById(id);
        }

        public IEnumerable<Persona> GetPersonas()
        {
            return this._unitOfWork.PersonaRepository.GetAll();
        }

        public async Task PostPersona(Persona o)
        {
            await this._unitOfWork.PersonaRepository.Add(o);
            await this._unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> PutPersona(Persona o)
        {
            this._unitOfWork.PersonaRepository.Update(o);
            await this._unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeletePersona(int id)
        {
            await this._unitOfWork.PersonaRepository.Delete(id);
            await this._unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
