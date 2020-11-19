using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.Entities
{
    public class FotoExp : BaseEntity
    {
        public string Nombre { get; set; }
        public int IdExpositor { get; set; }

        public virtual Expositor IdExpositorNavigation { get; set; }
    }
}
