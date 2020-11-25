using AutoMapper;
using Evento.Api.Response;
using Evento.Core.DTO;
using Evento.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramaController : ControllerBase
    {
        private readonly IvProgramaEjeTematicoService _ivProgramaEjeTematicoService;
        private readonly IMapper _mapper;

        public ProgramaController(IvProgramaEjeTematicoService ivProgramaEjeTematico, IMapper mapper)
        {
            this._ivProgramaEjeTematicoService = ivProgramaEjeTematico;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("todo")]
        public IActionResult GetProgramaEjeTematicos()
        {
            var response = new ApiResponse();
            try
            {
                var result = _ivProgramaEjeTematicoService.GetvProgramaEjeTematicos();
                var resultDto = _mapper.Map<IEnumerable<vProgramaEjeTematicoDto>>(result);


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
