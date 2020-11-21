using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evento.Api.Response
{
    public class UserResponse
    {
        public int IdPersona { get; set; }
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
