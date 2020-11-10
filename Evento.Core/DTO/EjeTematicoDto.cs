using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.DTO
{
    public class EjeTematicoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdCongreso { get; set; }
        public bool Estado { get; set; }
    }
}
