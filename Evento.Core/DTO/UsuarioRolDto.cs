using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.DTO
{
    public class UsuarioRolDto
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public bool Estado { get; set; }
    }
}
