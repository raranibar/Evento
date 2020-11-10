using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.DTO
{
    public class ComentarioDto
    {
        public int Id { get; set; }
        public string Comenta { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdEmprendedor { get; set; }
        public bool Estado { get; set; }
    }
}
