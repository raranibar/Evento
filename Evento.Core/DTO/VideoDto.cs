using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.DTO
{
    public class VideoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdEmprendedor { get; set; }
        public bool Estado { get; set; }
    }
}
