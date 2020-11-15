using System;
using System.Collections.Generic;

namespace Evento.Core.Entities
{
    public partial class Usuario : BaseEntity
    {
        public Usuario()
        {
            UsuarioRol = new HashSet<UsuarioRol>();
        }

        public string Email { get; set; }
        public string Clave { get; set; }
        public string ClaveSalt { get; set; }
        public int IdPersona { get; set; }
        public int IdCongreso { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual ICollection<UsuarioRol> UsuarioRol { get; set; }
        public virtual ICollection<CongresoUsuario> CongresoUsuario { get; set; }
    }
}
