using System;
using System.Collections.Generic;

namespace Evento.Core.Entities
{
    public partial class Participante : BaseEntity
    {
        public string Factura { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int? IdPersona { get; set; }
        public int IdCongreso { get; set; }

        public virtual Congreso IdCongresoNavigation { get; set; }
        public virtual Persona IdPersonaNavigation { get; set; }
    }
}
