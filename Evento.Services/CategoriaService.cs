﻿using Evento.Core.Entities;
using Evento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoriaService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }        

        public Task<Categoria> GetCategoria(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Categoria> GetCategorias()
        {
            return this._unitOfWork.CategoriaRepository.GetAll().Where(q => q.Estado == true);
        }

        public Task PostCategoria(Categoria o)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutCategoria(Categoria o)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteCategoria(int id)
        {
            throw new NotImplementedException();
        }
    }
}
