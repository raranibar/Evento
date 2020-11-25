using System;
using System.Collections.Generic;

namespace Evento.Core.Entities
{
    public partial class Expositor : BaseEntity
    {
        public Expositor()
        {
            FotoExp = new HashSet<FotoExp>();
            Horario = new HashSet<Horario>();
            Programa = new HashSet<Programa>();
        }
        public string NombreExposicion { get; set; }
        public string Institucion { get; set; }
        public string ResumenCv { get; set; }
        public int IdEjeTematico { get; set; }
        public int IdPersona { get; set; }

        public virtual EjeTematico IdEjeTematicoNavigation { get; set; }
        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual ICollection<Horario> Horario { get; set; }
        public virtual ICollection<FotoExp> FotoExp { get; set; }
        public virtual ICollection<Programa> Programa { get; set; }
    }
}
