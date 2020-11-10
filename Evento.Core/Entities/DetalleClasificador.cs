using System;
using System.Collections.Generic;

namespace Evento.Core.Entities
{
    public partial class DetalleClasificador : BaseEntity
    {
        public DetalleClasificador()
        {
            PersonaIdGeneroNavigation = new HashSet<Persona>();
            PersonaIdTipoDocumentoNavigation = new HashSet<Persona>();
        }

        public int IdClasificador { get; set; }
        public string Nombre { get; set; }
        public int Orden { get; set; }

        public virtual Clasificador IdClasificadorNavigation { get; set; }
        public virtual ICollection<Persona> PersonaIdGeneroNavigation { get; set; }
        public virtual ICollection<Persona> PersonaIdTipoDocumentoNavigation { get; set; }
    }
}
