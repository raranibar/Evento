using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.DTO
{
    public class FotoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdEmprendedor { get; set; }
        public bool Estado { get; set; }
    }
}
