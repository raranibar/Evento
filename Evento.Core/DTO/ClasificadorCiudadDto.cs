using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.DTO
{
    public class ClasificadorCiudadDto
    {
        public int Id { get; set; }
        public int IdPais { get; set; }
        public string Ciudad { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
