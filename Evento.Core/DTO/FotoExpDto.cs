using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.DTO
{
    public class FotoExpDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdExpositor { get; set; }
        public bool Estado { get; set; }
    }
}
