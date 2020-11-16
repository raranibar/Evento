using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.DTO
{
    public class ClasificadorPaisDto
    {
        public int Id { get; set; }
        public string Pais { get; set; }
        public bool Estado { get; set; }        
        public DateTime FechaRegistro { get; set; }

    }
}
