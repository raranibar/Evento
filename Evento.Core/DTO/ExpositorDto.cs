using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.DTO
{
    public class ExpositorDto
    {
        public int Id { get; set; }
        public string NombreExposicion { get; set; }
        public string Institucion { get; set; }
        public string ResumenCv { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdEjeTematico { get; set; }
        public int IdPersona { get; set; }
        public bool Estado { get; set; }
    }
}
