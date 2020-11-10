using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.DTO
{
    public class EmprendedorDto
    {
        public int Id { get; set; }
        public string NombreEmprendimiento { get; set; }
        public string Descripcion { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public int Raiting { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdPersona { get; set; }
        public int IdCategoria { get; set; }
        public bool Estado { get; set; }
    }
}
