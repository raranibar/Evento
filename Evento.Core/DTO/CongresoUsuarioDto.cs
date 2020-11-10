using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.DTO
{
    public class CongresoUsuarioDto
    {
        public int Id { get; set; }
        public int IdCongreso { get; set; }
        public int IdUsuario { get; set; }
        public bool Estado { get; set; }
    }
}
