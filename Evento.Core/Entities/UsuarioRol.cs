using System;
using System.Collections.Generic;

namespace Evento.Core.Entities
{
    public partial class UsuarioRol : BaseEntity
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }

        public virtual Rol IdRolNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
