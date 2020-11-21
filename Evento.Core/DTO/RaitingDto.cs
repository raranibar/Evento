using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.DTO
{
    public class RaitingDto
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public int IdEmprendedor { get; set; }
        public bool Estado { get; set; }
    }
}
