using Evento.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Core.Interfaces
{
    public interface IRepository<T> where T: BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(int Id);
        Task Add(T entity);
        void Update(T entity);
        Task Delete(int Id);
    }
}
