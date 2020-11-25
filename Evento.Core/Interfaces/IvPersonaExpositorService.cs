using Evento.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Core.Interfaces
{
    public interface IvPersonaExpositorService
    {
        IEnumerable<vPersonaExpositor> GevPersonaExpositors();

        Task<vPersonaExpositor> GetvPersonaExpositor(int id);
    }
}
