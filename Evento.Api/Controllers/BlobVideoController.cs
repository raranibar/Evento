using AutoMapper;
using Evento.Api.Response;
using Evento.Core.DTO;
using Evento.Core.Entities;
using Evento.Core.Entities.Blob;
using Evento.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IMapper _mapper;

        public BlobVideoController(IBlobService blobService, IVideoService videoService, IConfiguration configuration, IMapper mapper)
        {
            this._blobService = blobService;
            this._videoService = videoService;
            this._configuration = configuration;
            _mapper = mapper;
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

        /*  [HttpPost("uploadfile")]
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
           }*/

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



        [HttpPost("uploadmovie"), DisableRequestSizeLimit]
        public async Task<ActionResult> UploadProfileMovie([FromForm] VideoUploadFileDto data)
        {
            if (data.idDel != "-1")
            {
                var result = await _videoService.GetVideo(int.Parse(data.idDel));
                var resultDto = _mapper.Map<Video>(result);
                resultDto.Estado = false;
                await _videoService.PutVideo(resultDto);
            }
            if (data.files != null)
            {
                string container = this._configuration.GetValue<string>("EventoSettings:ContainerVid");
                var file = data.files;

                var guidImage = Guid.NewGuid().ToString("N");
                var result = await _blobService.UploadFileBlobAsync(file.OpenReadStream(), file.ContentType, guidImage, container);
                var oVideo = new Video
                {
                    IdEmprendedor = data.idEmprendedor,
                    Nombre = result.ToString()
                };

                await this._videoService.PostVideo(oVideo);
                if (file == null)
                {
                    return BadRequest();
                }
                var toReturn = true;

                return Ok(new { path = toReturn });
            }
            return Ok(new { path = false });
        }



        [HttpGet]
        [Route("video")]
        public IActionResult GetVideo(int id)
        {
            var response = new ApiResponse();
            try
            {
                var result = _videoService.GetVideos().Where(x => x.IdEmprendedor == id&& x.Estado==true);
                var resultDto = _mapper.Map<IEnumerable<VideoDto>>(result);
                response.Exito = 1;
                response.Data = resultDto;
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }
    }
}
