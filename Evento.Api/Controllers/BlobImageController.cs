using Evento.Api.Response;
using Evento.Core.DTO;
using Evento.Core.Entities;
using Evento.Core.Entities.Blob;
using Evento.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Evento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlobImageController : ControllerBase
    {
        private readonly IBlobService _blobService;
        private readonly IFotoService _fotoService;
        private readonly IFotoExpService _fotoExpService;
        private readonly IConfiguration _configuration;
        
        public BlobImageController(IBlobService blobService, IFotoService fotoService, IFotoExpService _fotoExpService, IConfiguration configuration)
        {
            this._blobService = blobService;
            this._fotoService = fotoService;
            this._fotoExpService = _fotoExpService;
            this._configuration = configuration;
        }

        [HttpGet("{blobName}")]
        public async Task<IActionResult> GetBlob(string blobName)
        {
            string container = this._configuration.GetValue<string>("EventoSettings:ContainerImg");
            var data = await _blobService.GetBlobAsync(blobName,container);
            return File(data.Content, data.ContentType);
        }

        [HttpGet("list")]
        public async Task<IActionResult> ListBlobs()
        {
            string container = this._configuration.GetValue<string>("EventoSettings:ContainerImg");
            return Ok(await _blobService.ListBlobsAsync(container));
        }

        [HttpPost]
        [Route("uploadfile")]
        public async Task<IActionResult> UploadFile([FromBody] FotoUploadFileDto request)
        {
            var response = new ApiResponse();
            try
            {
                string container = this._configuration.GetValue<string>("EventoSettings:ContainerImg");
                string urlblob = this._configuration.GetValue<string>("EventoSettings:UrlBlobImages");
                string ext = request.FileName.Substring(request.FileName.Length - 4, 4);
                var guidImage = Guid.NewGuid().ToString("N");
                request.FileName = guidImage.ToString() + ext;
                var oFoto = new Foto
                {
                    IdEmprendedor = request.IdEmprendedor,
                    Nombre = string.Concat(urlblob, request.FileName)
                };           
                await this._fotoService.PostFoto(oFoto);
                await _blobService.UploadFileBlobAsync(request.FilePath, request.FileName, container);
                response.Exito = 1;
                response.Data = "Foto Cargada en el repositorio";
            }
            catch(Exception ex)
            {
                response.Mensaje = ex.Message;
            }                                   
            return Ok(response);
        }

        [HttpPost]
        [Route("uploadfileexp")]
        public async Task<IActionResult> UploadFileExp([FromBody] FotoExpUploadFileDto request)
        {
            var response = new ApiResponse();
            try
            {
                string container = this._configuration.GetValue<string>("EventoSettings:ContainerImg");
                string urlblob = this._configuration.GetValue<string>("EventoSettings:UrlBlobImages");
                string ext = request.FileName.Substring(request.FileName.Length - 4, 4);
                var guidImage = Guid.NewGuid().ToString("N");
                request.FileName = guidImage.ToString() + ext;
                var oFotoExp = new FotoExp
                {
                    IdExpositor = request.IdExpositor,
                    Nombre = string.Concat(urlblob, request.FileName)
                };
                await this._fotoExpService.PostFotoExp(oFotoExp);
                await _blobService.UploadFileBlobAsync(request.FilePath, request.FileName, container);
                response.Exito = 1;
                response.Data = "Foto Expositor Cargada en el repositorio";
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("uploadcontent")]
        public async Task<IActionResult> UploadContent([FromBody] UploadContentRequest request)
        {
            string container = this._configuration.GetValue<string>("EventoSettings:ContainerImg");
            await _blobService.UploadContentBlobAsync(request.Content, request.FileName,container);
            return Ok();
        }

        [HttpPost("uploadpicture"), DisableRequestSizeLimit]
        public async Task<ActionResult> UploadProfilePicture()
        {
            string container = this._configuration.GetValue<string>("EventoSettings:ContainerImg");
            IFormFile file = Request.Form.Files[0];
            if (file == null)
            {
                return BadRequest();
            }

            var result = await _blobService.UploadFileBlobAsync(file.OpenReadStream(), file.ContentType, file.FileName, container);
            var toReturn = result.AbsoluteUri;

            return Ok(new { path = toReturn });
        }

        [HttpDelete("{blobName}")]
        public async Task<IActionResult> DeleteFile(string blobName)
        {
            string container = this._configuration.GetValue<string>("EventoSettings:ContainerImg");
            await _blobService.DeleteBlobAsync(blobName, container);
            return Ok();
        }
    }
}
