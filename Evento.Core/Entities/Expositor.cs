using System;
using System.Collections.Generic;

namespace Evento.Core.Entities
{
    public partial class Expositor : BaseEntity
    {
        public Expositor()
        {
            Horario = new HashSet<Horario>();
        }

        public string NombreExposicion { get; set; }
        public string Institucion { get; set; }
        public string Pais { get; set; }
        public string Departamento { get; set; }
        public string ResumenCv { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdEjeTematico { get; set; }
        public int IdPersona { get; set; }

        public virtual EjeTematico IdEjeTematicoNavigation { get; set; }
        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual ICollection<Horario> Horario { get; set; }
    }
}
