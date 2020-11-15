using System;
using System.Collections.Generic;

namespace Evento.Core.Entities
{
    public partial class Categoria : BaseEntity
    {
        public Categoria()
        {
            Emprendedor = new HashSet<Emprendedor>();
        }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Logo { get; set; }
        public int IdCongreso { get; set; }

        public virtual Congreso IdCongresoNavigation { get; set; }
        public virtual ICollection<Emprendedor> Emprendedor { get; set; }
    }
}
