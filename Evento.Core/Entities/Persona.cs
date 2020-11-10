using System;
using System.Collections.Generic;

namespace Evento.Core.Entities
{
    public partial class Persona : BaseEntity
    {
        public Persona()
        {
            Emprendedor = new HashSet<Emprendedor>();
            Expositor = new HashSet<Expositor>();
            Participante = new HashSet<Participante>();
            Usuario = new HashSet<Usuario>();
        }

        public string Nombres { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public int? IdGenero { get; set; }
        public string Fono { get; set; }
        public string Direccion { get; set; }
        public string NumDocumento { get; set; }
        public int IdTipoDocumento { get; set; }
        public DateTime FechaRegistro { get; set; }

        public virtual DetalleClasificador IdGeneroNavigation { get; set; }
        public virtual DetalleClasificador IdTipoDocumentoNavigation { get; set; }
        public virtual ICollection<Emprendedor> Emprendedor { get; set; }
        public virtual ICollection<Expositor> Expositor { get; set; }
        public virtual ICollection<Participante> Participante { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
