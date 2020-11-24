using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using Evento.Api.Response;
using Evento.Core.DTO;
using Evento.Core.Entities;
using Evento.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Evento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpositorController : ControllerBase
    {
    
        private readonly IPersonaService _personaService;
        private readonly IExpositorService _expositorService;

        private readonly IMapper _mapper;

        public ExpositorController(
           IPersonaService personaService, IExpositorService expositorService,
           IMapper mapper)
        {
            _personaService = personaService;
            _expositorService = expositorService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetExpositores()
        {
            var response = new ApiResponse();
            try
            {
                var result = _expositorService.GetExpositores();
                var resultDto = _mapper.Map<IEnumerable<ExpositorDto>>(result);

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
        [Route("eje")]
        public IActionResult GetExpositoresByEje(int id)
        {
            var response = new ApiResponse();
            try
            {
                var result = _expositorService.GetExpositores().Where(x=>x.IdEjeTematico==id);
                var resultDto = _mapper.Map<IEnumerable<ExpositorDto>>(result);


                response.Exito = 1;
                response.Data = resultDto;
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpositor(int id)
        {
            var response = new ApiResponse();
            try
            {
                var rExpositor = await _expositorService.GetExpositor(id);
                var expositorDto = _mapper.Map<ExpositorDto>(rExpositor);

                var rPersona = await _personaService.GetPersona(expositorDto.IdPersona);
                var personaDto= _mapper.Map<PersonaDto>(rPersona);

                var data = new
                {
                    persona = personaDto,
                    expositor = expositorDto
                };

                response.Exito = 1;
                response.Data = data;
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }






        [HttpPost]
        public async Task<IActionResult> PostExpositor(ExpositorPersonaDto expositorPersonaDto)
        {
            var response = new ApiResponse();
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var oPersona = _mapper.Map<Persona>(expositorPersonaDto);
                    await _personaService.PostPersona(oPersona);

                    var oExpositor = _mapper.Map<Expositor>(expositorPersonaDto);
                    oExpositor.IdPersona = oPersona.Id;
                    await _expositorService.PostExpositor(oExpositor);

                    var idExp = _expositorService.GetExpositores().Where(x => x.IdPersona == oPersona.Id).ToList();
                    var oIdExp= _mapper.Map<ExpositorDto>(idExp[0]);


                    response.Exito = 1;
                    response.Data = oIdExp.Id;
                    response.Mensaje = "Expositor registrado correctamente";
                    transaction.Complete();

                }
                catch (Exception ex)
                {
                    response.Mensaje = ex.Message;
                }
                return Ok(response);

            }

        }

        [HttpPut]
        public async Task<IActionResult> PutExpositor(ExpositorDto expositorDto)
        {
            var response = new ApiResponse();
            try
            {
                var oExpositor = _mapper.Map<Expositor>(expositorDto);
                oExpositor.Estado = true;
                bool result = await _expositorService.PutExpositor(oExpositor);

                response.Exito = 1;
                response.Data = true;
                response.Mensaje = "Expositor modificado correctamente";
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

       [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpositor(int id)
        {
            var response = new ApiResponse();
            try
            {
                var rExpositor = await _expositorService.GetExpositor(id);
                var expositorDto = _mapper.Map<Expositor>(rExpositor);
                expositorDto.Estado = false;
                bool result = await _expositorService.PutExpositor(expositorDto);

                response.Exito = 1;
                response.Data = true;
                response.Mensaje = "Expositor eliminado correctamente";
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }
    }

  
}