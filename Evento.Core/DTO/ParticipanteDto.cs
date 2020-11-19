using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.DTO
{
    public class ParticipanteDto
    {
        public int Id { get; set; }
        public string Factura { get; set; }
        public int? IdPersona { get; set; }
        public int IdCongreso { get; set; }
        public bool Estado { get; set; }
    }
}
