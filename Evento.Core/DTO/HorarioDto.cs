using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.DTO
{
    public class HorarioDto
    {
        public int Id { get; set; }
        public string Horario1 { get; set; }
        public string UrlZoom { get; set; }
        public string IdReunionZoom { get; set; }
        public string CodigoAccesoZoom { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdFecha { get; set; }
        public int IdExpositor { get; set; }
        public bool Estado { get; set; }
    }
}
