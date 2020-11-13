using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evento.Api.Response
{
    public class ApiResponse
    {
        public int Exito { get; set; }
        public string Mensaje { get; set; }
        public Object Data { get; set; }

        public ApiResponse()
        {
            Data = null;
            Exito = 0;
            Mensaje = string.Empty;
        }
    }
}
