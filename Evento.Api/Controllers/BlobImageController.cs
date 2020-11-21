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
    public class BlobImageController : ControllerBase
    {
        private readonly IBlobService _blobService;
        private readonly IFotoService _fotoService;
        private readonly IFotoExpService _fotoExpService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public BlobImageController(IBlobService blobService, IFotoService fotoService, IFotoExpService _fotoExpService, IConfiguration configuration, IMapper mapper)
        {
            this._blobService = blobService;
            this._fotoService = fotoService;
            this._fotoExpService = _fotoExpService;
            this._configuration = configuration;
            _mapper = mapper;
        }

        [HttpGet("{blobName}")]
        public async Task<IActionResult> GetBlob(string blobName)
        {
            string container = this._configuration.GetValue<string>("EventoSettings:ContainerImg");
            var data = await _blobService.GetBlobAsync(blobName, container);
            return File(data.Content, data.ContentType);
        }

        [HttpGet("list")]
        public async Task<IActionResult> ListBlobs()
        {
            string container = this._configuration.GetValue<string>("EventoSettings:ContainerImg");
            return Ok(await _blobService.ListBlobsAsync(container));
        }


        [HttpGet]
        [Route("images")]
        public IActionResult GetImages(int id)
        {
            var response = new ApiResponse();
            try
            {
                var result = _fotoService.GetFotos().Where(x => x.IdEmprendedor == id);
                var resultDto = _mapper.Map<IEnumerable<FotoDto>>(result);
                response.Exito = 1;
                response.Data = resultDto;
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        /*[HttpPost]
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
        }*/

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
            await _blobService.UploadContentBlobAsync(request.Content, request.FileName, container);
            return Ok();
        }

        [HttpPost("uploadpicture"), DisableRequestSizeLimit]
        public async Task<ActionResult> UploadProfilePicture([FromForm] FotoUploadFileDto data)
        {
            string container = this._configuration.GetValue<string>("EventoSettings:ContainerImg");
            //IFormFile file = Request.Form.Files[0];

            foreach (var item in data.imgDel)
            {
                await _fotoService.DeleteFoto(int.Parse(item));
            }
            if (data.files != null)
            {
                foreach (var item in data.files)
                {
                    var guidImage = Guid.NewGuid().ToString("N");
                    var result = await _blobService.UploadFileBlobAsync(item.OpenReadStream(), item.ContentType, guidImage + item.FileName, container);
                    var oFoto = new Foto
                    {
                        IdEmprendedor = data.idEmprendedor,
                        Nombre = result.ToString()
                    };
                    await this._fotoService.PostFoto(oFoto);
                }
                if (data.files == null)
                {
                    return BadRequest();
                }
            }
            var toReturn = true;

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
