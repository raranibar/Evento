using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Core.DTO
{
    public class VideoUploadFileDto
    {
        public int idEmprendedor { get; set; }
        public IFormFile files { get; set; }
        public string idDel { get; set; }
    }
}
