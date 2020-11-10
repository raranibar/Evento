using System;
using System.Collections.Generic;

namespace Evento.Core.Entities
{
    public partial class Congreso : BaseEntity
    {
        public Congreso()
        {
            Categoria = new HashSet<Categoria>();
            EjeTematico = new HashSet<EjeTematico>();
            Fecha = new HashSet<Fecha>();
            PaginaInformacion = new HashSet<PaginaInformacion>();
            PaginaMemoria = new HashSet<PaginaMemoria>();
            Participante = new HashSet<Participante>();
        }

        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Responsable { get; set; }
        public string Logo { get; set; }
        public DateTime FechaRegistro { get; set; }

        public virtual ICollection<Categoria> Categoria { get; set; }
        public virtual ICollection<EjeTematico> EjeTematico { get; set; }
        public virtual ICollection<Fecha> Fecha { get; set; }
        public virtual ICollection<PaginaInformacion> PaginaInformacion { get; set; }
        public virtual ICollection<PaginaMemoria> PaginaMemoria { get; set; }
        public virtual ICollection<Participante> Participante { get; set; }
    }
}
