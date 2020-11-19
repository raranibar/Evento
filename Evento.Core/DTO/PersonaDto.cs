using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.DTO
{
    public class PersonaDto
    {
        public int Id { get; set; }
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
        public bool Estado { get; set; }
    }
}
