using System;
using System.Collections.Generic;

namespace Evento.Core.Entities
{
    public partial class Clasificador : BaseEntity
    {
        public Clasificador()
        {
            DetalleClasificador = new HashSet<DetalleClasificador>();
        }

        public string Descripcion { get; set; }

        public virtual ICollection<DetalleClasificador> DetalleClasificador { get; set; }
    }
}
