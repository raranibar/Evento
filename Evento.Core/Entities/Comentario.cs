﻿using System;
using System.Collections.Generic;

namespace Evento.Core.Entities
{
    public partial class Comentario : BaseEntity
    {
        public string Comenta { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdEmprendedor { get; set; }

        public virtual Emprendedor IdEmprendedorNavigation { get; set; }
    }
}
