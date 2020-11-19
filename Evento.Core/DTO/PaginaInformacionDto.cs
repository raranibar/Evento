using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.DTO
{
    public class PaginaInformacionDto
    {
        public int Id { get; set; }
        public string Informacion { get; set; }
        public int IdCongreso { get; set; }
        public bool Estado { get; set; }
    }
}
