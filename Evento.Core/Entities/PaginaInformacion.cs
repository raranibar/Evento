using System;
using System.Collections.Generic;

namespace Evento.Core.Entities
{
    public partial class PaginaInformacion : BaseEntity
    {
        public string Informacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdCongreso { get; set; }

        public virtual Congreso IdCongresoNavigation { get; set; }
    }
}
