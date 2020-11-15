using System;
using System.Collections.Generic;

namespace Evento.Core.Entities
{
    public partial class Fecha : BaseEntity
    {
        public Fecha()
        {
            Horario = new HashSet<Horario>();
        }

        public DateTime Fecha1 { get; set; }
        public int IdCongreso { get; set; }

        public virtual Congreso IdCongresoNavigation { get; set; }
        public virtual ICollection<Horario> Horario { get; set; }
    }
}
