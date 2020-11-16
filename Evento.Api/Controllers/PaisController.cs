using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Evento.Api.Response;
using Evento.Core.Entities;
using Evento.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Evento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private readonly IClasificadorPaisService _clasificadorPaisService;
        private readonly IClasificadorCiudadService _clasificadorCiudadService;
        private readonly IMapper _mapper;
        public PaisController(
            IClasificadorPaisService clasificadorPaisService, IClasificadorCiudadService clasificadorCiudadService,
            IMapper mapper
            )
        {

            _clasificadorPaisService = clasificadorPaisService;
            _clasificadorCiudadService = clasificadorCiudadService;

            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetPais()
        {
            var response = new ApiResponse();
            try
            {
                var result = _clasificadorPaisService.GetClasificadorPaises();
                var resultDto = _mapper.Map<IEnumerable<ClasificadorPais>>(result);
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