using System;
using System.Collections.Generic;

namespace Evento.Core.Entities
{
    public partial class EjeTematico : BaseEntity
    {
        public EjeTematico()
        {
            Expositor = new HashSet<Expositor>();
            Programa = new HashSet<Programa>();
        }

        public string Nombre { get; set; }
        public int IdCongreso { get; set; }

        public virtual Congreso IdCongresoNavigation { get; set; }
        public virtual ICollection<Expositor> Expositor { get; set; }
        public virtual ICollection<Programa> Programa { get; set; }
    }
}
