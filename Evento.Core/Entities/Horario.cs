using System;
using System.Collections.Generic;

namespace Evento.Core.Entities
{
    public partial class Horario : BaseEntity
    {
        public string Horario1 { get; set; }
        public string UrlZoom { get; set; }
        public string IdReunionZoom { get; set; }
        public string CodigoAccesoZoom { get; set; }
        public int IdFecha { get; set; }
        public int IdExpositor { get; set; }

        public virtual Expositor IdExpositorNavigation { get; set; }
        public virtual Fecha IdFechaNavigation { get; set; }
    }
}
