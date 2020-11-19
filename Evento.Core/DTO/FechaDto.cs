using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.DTO
{
    public class FechaDto
    {
        public int Id { get; set; }
        public DateTime Fecha1 { get; set; }
        public int IdCongreso { get; set; }
        public bool Estado { get; set; }
    }
}
