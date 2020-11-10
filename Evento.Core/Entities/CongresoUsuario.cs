using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.Entities
{
    public class CongresoUsuario : BaseEntity
    {
        public int IdCongreso { get; set; }
        public int IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual Congreso IdCongresoNavigation { get; set; }
    }
}
