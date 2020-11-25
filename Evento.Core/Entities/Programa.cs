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
        public int IdExpositor { get; set; }

        public virtual Expositor IdExpositorNavigation { get; set; }
        public virtual Sala IdSalaNavigation { get; set; }
    }
}
