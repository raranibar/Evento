using System;
using System.Collections.Generic;

namespace Evento.Core.Entities
{
    public partial class EmprendedorRedSocial : BaseEntity
    {
        public int IdEmprendedor { get; set; }
        public int IdRedSocial { get; set; }
        public string Direccion { get; set; }

        public virtual Emprendedor IdEmprendedorNavigation { get; set; }
        public virtual RedSocial IdRedSocialNavigation { get; set; }
    }
}
