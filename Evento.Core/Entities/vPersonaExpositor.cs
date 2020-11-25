using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.Entities
{
    public class vPersonaExpositor : BaseEntity
    {        
        public string Nombres { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Pais { get; set; }
        public int IdEjeTematico { get; set; }
        public string NombreExposicion { get; set; }
        public string Institucion { get; set; }
        public string ResumenCV { get; set; }
        public string Foto { get; set; }     
    }
}
