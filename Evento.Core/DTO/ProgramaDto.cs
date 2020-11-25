using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.DTO
{
    public class ProgramaDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string UrlZoom { get; set; }
        public string IdReunionZoom { get; set; }
        public string CodigoAccesoZoom { get; set; }

        public int IdSala { get; set; }
        public int IdExpositor { get; set; }
    }
}
