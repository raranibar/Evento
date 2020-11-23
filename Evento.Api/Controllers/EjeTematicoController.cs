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
    public class EjeTematicoController : ControllerBase
    {
        private readonly IEjeTematicoService _ejeTematicoService;
        private readonly IMapper _mapper;

        public EjeTematicoController(IEjeTematicoService ejeTematicoService, IMapper mapper)
        {
            _ejeTematicoService = ejeTematicoService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetEjeTematico(int id)
        {
            var response = new ApiResponse();
            try
            {
                var result = _ejeTematicoService.GetEjeTematicos().Where(x=>x.IdCongreso==id);
                var resultDto = _mapper.Map<IEnumerable<EjeTematicoDto>>(result);

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