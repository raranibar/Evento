using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.DTO
{
    public class CategoriaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Logo { get; set; }
        public bool Estado { get; set; }
    }
}
