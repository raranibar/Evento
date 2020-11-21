using System;
using System.Collections.Generic;

namespace Evento.Core.Entities
{
    public partial class Emprendedor : BaseEntity
    {
        public Emprendedor()
        {
            Comentario = new HashSet<Comentario>();
            EmprendedorRedSocial = new HashSet<EmprendedorRedSocial>();
        }

        public string NombreEmprendimiento { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public int IdPersona { get; set; }
        public int IdCategoria { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual ICollection<Comentario> Comentario { get; set; }
        public virtual ICollection<Foto> Foto { get; set; }
        public virtual ICollection<Raiting> Raiting { get; set; }
        public virtual ICollection<Video> Video { get; set; }
        public virtual ICollection<EmprendedorRedSocial> EmprendedorRedSocial { get; set; }
    }
}
