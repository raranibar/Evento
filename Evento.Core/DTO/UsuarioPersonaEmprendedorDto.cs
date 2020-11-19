using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.DTO
{
    public class UsuarioPersonaEmprendedorDto
    {
        public int Id { get; set; }
        public int IdEmprendedor { get; set; }
        public int IdRedSocial { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; }
    }
}
