using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.DTO
{
    public class PersonaUsuarioDto
    {
        public int IdPersona { get; set; }
        public int IdUsuario { get; set; }


        public string Nombres { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public int IdGenero { get; set; }
        public string Fono { get; set; }
        public int IdPais { get; set; }
        public int IdCiudad { get; set; }
        public string Direccion { get; set; }
        public string NumDocumento { get; set; }
        public int IdTipoDocumento { get; set; }        
        public string Email { get; set; }
        public int IdCongreso { get; set; }
        public int IdRol { get; set; }
    }
}
