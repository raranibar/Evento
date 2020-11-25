using Evento.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Core.Interfaces
{
    public interface IvProgramaEjeTematicoService
    {
        IEnumerable<vProgramaEjeTematico> GetvProgramaEjeTematicos();

        Task<vProgramaEjeTematico> GetvPProgramaEjeTematico(int id);
    }
}
