using System;
using System.Collections.Generic;

namespace Evento.Core.Entities
{
    public partial class ClasificadorPais : BaseEntity
    {
        public ClasificadorPais()
        {
            ClasificadorCiudad = new HashSet<ClasificadorCiudad>();
            Persona = new HashSet<Persona>();
        }

        public string Pais { get; set; }

        public virtual ICollection<ClasificadorCiudad> ClasificadorCiudad { get; set; }
        public virtual ICollection<Persona> Persona { get; set; }
    }
}
