using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.Entities
{
    public class vProgramaEjeTematico : BaseEntity
    {       
       public string Fecha { get; set; }
       public string Hora { get; set; }
       public string UrlZoom { get; set; }
       public string IdReunionZoom { get; set; }
       public string CodigoAccesoZoom { get; set; }
       public string NombreSala { get; set; }
       public int IdEjeTematico { get; set; }
       public string NombreEjeTematico { get; set; }
    }
}
