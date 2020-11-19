using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.DTO
{
    public class CongresoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Responsable { get; set; }
        public string Logo { get; set; }
        public bool Estado { get; set; }
        //public DateTime FechaRegistro { get; set; }
    }
}
