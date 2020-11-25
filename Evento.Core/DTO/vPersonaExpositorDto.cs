using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.DTO
{
    public class vPersonaExpositorDto
    {
        public int Id { get; set; }
        public int IdPersona { get; set; }
        public string Nombres { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Pais { get; set; }
        public int IdEjeTematico { get; set; }
        public int IdExpositor { get; set; }
        public string NombreExposicion { get; set; }
        public string Institucion { get; set; }
        public string ResumenCv { get; set; }
        public string Foto { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
