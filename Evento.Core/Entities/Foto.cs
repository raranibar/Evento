﻿namespace Evento.Core.Entities
{
    public partial class Foto : BaseEntity
    {
        public string Nombre { get; set; }
        public int IdEmprendedor { get; set; }        
        public virtual Emprendedor IdEmprendedorNavigation { get; set; }
    }
}
