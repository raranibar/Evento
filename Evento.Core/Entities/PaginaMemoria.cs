using System;
using System.Collections.Generic;

namespace Evento.Core.Entities
{
    public partial class PaginaMemoria : BaseEntity
    {
        public string Memoria { get; set; }
        public int IdCongreso { get; set; }

        public virtual Congreso IdCongresoNavigation { get; set; }
    }
}
