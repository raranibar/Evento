using AutoMapper;
using Evento.Api.Response;
using Evento.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Evento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaitingController : ControllerBase
    {
        private readonly IRaitingService _raitingService;
        private readonly IMapper _mapper;

        public RaitingController(IRaitingService raitingService, IMapper mapper)
        {
            _raitingService = raitingService;
            _mapper = mapper;
        }

        [HttpGet("{IdEmprendedor}")]
        public IActionResult Get(int IdEmprendedor)
        {
            var response = new ApiResponse();
            try
            {
                var result = _raitingService.RaitingEmprendedor(IdEmprendedor);
                //var resultDto = _mapper.Map<IEnumerable<CongrDto>>(result);
                response.Exito = 1;
                //response.Data = resultDto;
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }
    }
}
