using System;
using System.Collections.Generic;

namespace Evento.Core.Entities
{
    public partial class Sala : BaseEntity
    {
        public Sala()
        {
            Programa = new HashSet<Programa>();
        }

        public string Nombre { get; set; }


        public virtual ICollection<Programa> Programa { get; set; }
    }
}
