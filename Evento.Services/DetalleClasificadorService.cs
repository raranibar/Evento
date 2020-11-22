using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Services
{
    public class DetalleClasificadorService : IDetalleClasificadorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DetalleClasificadorService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public Task<DetalleClasificador> GetDetalleClasificador(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DetalleClasificador> GetDetalleClasificadores()
        {
            return this._unitOfWork.DetalleClasificadorRepository.GetAll().Where(x=>x.Estado==true);

        }

        public Task PostDetalleClasificador(DetalleClasificador o)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutDetalleClasificador(DetalleClasificador o)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteDetalleClasificador(int id)
        {
            throw new NotImplementedException();
        }
    }
}
