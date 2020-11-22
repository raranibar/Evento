using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.DTO
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        //public string ClaveSalt { get; set; }
        public int IdPersona { get; set; }
        public int IdCongreso { get; set; }
        public bool Estado { get; set; }
    }
}
