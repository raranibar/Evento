using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.DTO
{
    public class RedSocialDto
    {
        public int Id { get; set; }
        public int Nombre { get; set; }
        public string Logo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Estado { get; set; }
    }
}
