using System;
using System.Collections.Generic;

namespace Evento.Core.Entities
{
    public partial class EjeTematico : BaseEntity
    {
        public EjeTematico()
        {
            Expositor = new HashSet<Expositor>();
        }

        public string Nombre { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdCongreso { get; set; }

        public virtual Congreso IdCongresoNavigation { get; set; }
        public virtual ICollection<Expositor> Expositor { get; set; }
    }
}
