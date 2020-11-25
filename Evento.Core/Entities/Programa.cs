using System;
using System.Collections.Generic;

namespace Evento.Core.Entities
{
    public partial class Programa : BaseEntity
    {

        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string UrlZoom { get; set; }
        public string IdReunionZoom { get; set; }
        public string CodigoAccesoZoom { get; set; }

        public int IdSala { get; set; }
        public int IdEjeTematico { get; set; }

        public virtual EjeTematico IdEjeTematicoNavigation { get; set; }
        public virtual Sala IdSalaNavigation { get; set; }
    }
}
