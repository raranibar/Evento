using System;
using System.Collections.Generic;

namespace Evento.Core.Entities
{
    public partial class ClasificadorCiudad : BaseEntity
    {
        public ClasificadorCiudad()
        {
            Persona = new HashSet<Persona>();
        }

        public int IdPais { get; set; }
        public string Ciudad { get; set; }


        public virtual ClasificadorPais IdPaisNavigation { get; set; }
        public virtual ICollection<Persona> Persona { get; set; }
    }
}
