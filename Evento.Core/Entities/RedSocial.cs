using System;
using System.Collections.Generic;

namespace Evento.Core.Entities
{
    public partial class RedSocial : BaseEntity
    {
        public RedSocial()
        {
            EmprendedorRedSocial = new HashSet<EmprendedorRedSocial>();
        }

        public int Nombre { get; set; }
        public string Logo { get; set; }

        public virtual DetalleClasificador IdRedSocialNavigation { get; set; }
        public virtual ICollection<EmprendedorRedSocial> EmprendedorRedSocial { get; set; }
    }
}
