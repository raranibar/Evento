using Evento.Api.Response;
using Evento.Core.DTO;
using Evento.Core.Entities;
using Evento.Core.Entities.Blob;
using Evento.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Evento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlobVideoController : ControllerBase
    {
        private readonly IBlobService _blobService;
        private readonly IVideoService _videoService;
        private readonly IConfiguration _configuration;
        public BlobVideoController(IBlobService blobService, IVideoService videoService, IConfiguration configuration)
        {
            this._blobService = blobService;
            this._videoService = videoService;
            this._configuration = configuration;
        }

        [HttpGet("{blobName}")]
        public async Task<IActionResult> GetBlob(string blobName)
        {
            string container = this._configuration.GetValue<string>("EventoSettings:ContainerVid");
            var data = await _blobService.GetBlobAsync(blobName, container);
            return File(data.Content, data.ContentType);
        }

        [HttpGet("list")]
        public async Task<IActionResult> ListBlobs()
        {
            string container = this._configuration.GetValue<string>("EventoSettings:ContainerVid");
            return Ok(await _blobService.ListBlobsAsync(container));
        }

        [HttpPost("uploadfile")]
        public async Task<IActionResult> UploadFile([FromBody] VideoUploadFileDto request)
        {
            var response = new ApiResponse();
            try
            {
                string container = this._configuration.GetValue<string>("EventoSettings:ContainerVid");
                string urlblob = this._configuration.GetValue<string>("EventoSettings:UrlBlobVideos");
                string ext = request.FileName.Substring(request.FileName.Length - 4, 4);
                var guidImage = Guid.NewGuid().ToString("N");
                request.FileName = guidImage.ToString() + ext;
                var oVideo = new Video
                {
                    IdEmprendedor = request.IdEmprendedor,
                    Nombre = string.Concat(urlblob, request.FileName)
                };
                await this._videoService.PostVideo(oVideo);
                await _blobService.UploadFileBlobAsync(request.FilePath, request.FileName, container);
                response.Exito = 1;
                response.Data = "Video Cargado en el repositorio";
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
            string container = this._configuration.GetValue<string>("EventoSettings:ContainerVid");
            await _blobService.UploadContentBlobAsync(request.Content, request.FileName, container);
            return Ok();
        }

        [HttpDelete("{blobName}")]
        public async Task<IActionResult> DeleteFile(string blobName)
        {
            string container = this._configuration.GetValue<string>("EventoSettings:ContainerVid");
            await _blobService.DeleteBlobAsync(blobName, container);
            return Ok();
        }
    }
}
