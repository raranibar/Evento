using System;
using System.Collections.Generic;

namespace Evento.Core.Entities
{
    public partial class Rol : BaseEntity
    {
        public Rol()
        {
            UsuarioRol = new HashSet<UsuarioRol>();
        }

        public string Nombre { get; set; }
        public DateTime FechaRegistro { get; set; }

        public virtual ICollection<UsuarioRol> UsuarioRol { get; set; }
    }
}
