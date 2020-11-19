using System;
using System.Collections.Generic;

namespace Evento.Core.Entities
{
    public partial class Video : BaseEntity
    {
        public string Nombre { get; set; }
        public int IdEmprendedor { get; set; }

        public virtual Emprendedor IdEmprendedorNavigation { get; set; }
    }
}
