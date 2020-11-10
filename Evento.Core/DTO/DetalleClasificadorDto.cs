using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.DTO
{
    public class DetalleClasificadorDto
    {
        public int Id { get; set; }
        public int IdClasificador { get; set; }
        public string Nombre { get; set; }
        public int Orden { get; set; }
        public bool Estado { get; set; }
    }
}
