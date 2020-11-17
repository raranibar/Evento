using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Evento.Api.Response;
using Evento.Core.DTO;
using Evento.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Evento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasificadorController : ControllerBase
    {
        private readonly IDetalleClasificadorService _detalleClasificadorService;
        private readonly IMapper _mapper;
        public ClasificadorController(IDetalleClasificadorService detalleClasificadorService, IMapper mapper)
        {
            _detalleClasificadorService = detalleClasificadorService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Documento")]
        public IActionResult GetDocumento()
        {
            var response = new ApiResponse();
            try
            {
                var result = _detalleClasificadorService.GetDetalleClasificadores().Where(x=>x.IdClasificador==1);
                var resultDto = _mapper.Map<IEnumerable<DetalleClasificadorDto>>(result);
                response.Exito = 1;
                response.Data = resultDto;
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("Genero")]
        public IActionResult GetGenero()
        {
            var response = new ApiResponse();
            try
            {
                var result = _detalleClasificadorService.GetDetalleClasificadores().Where(x => x.IdClasificador == 2);
                var resultDto = _mapper.Map<IEnumerable<DetalleClasificadorDto>>(result);
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