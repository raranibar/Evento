using Evento.Core.Entities;
using Evento.Core.Interfaces;
using Evento.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private DbSet<T> _entities;

        public BaseRepository(EventoDevContext context)
        {
            this._entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return this._entities.AsEnumerable();
        }

        public async Task<T> GetById(int Id)
        {
            return await this._entities.FindAsync(Id);
        }

        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public async Task Delete(int Id)
        {
            var entity = await GetById(Id);
            _entities.Remove(entity);
        }
    }
}
