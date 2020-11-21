using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.DTO
{
    public class FotoUploadFileDto
    {
        public int idEmprendedor { get; set; }
        public IFormFile[] files { get; set; }
        public string[] imgDel { get; set; }
    }
}
