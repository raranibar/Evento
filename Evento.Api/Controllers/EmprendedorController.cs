using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class EmprendedorController : ControllerBase
    {
        private readonly IEmprendedorService _emprendedorService;
        private readonly IEmprendedorRedSocialService _emprendedorRedSocialService;
        private readonly IRedSocialService _redSocialService;
        private readonly IUsuarioService _usuarioService;
        private readonly IPersonaService _personaService;

        private readonly IMapper _mapper;

        public EmprendedorController(IEmprendedorService emprendedorService, 
            IEmprendedorRedSocialService emprendedorRedSocialService, IRedSocialService redSocialService,
            IUsuarioService _usuarioService, IPersonaService personaService,
            IMapper mapper)
        {
            _emprendedorService = emprendedorService;
            _emprendedorRedSocialService = emprendedorRedSocialService;
            _redSocialService = redSocialService;
            _personaService = personaService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("todo")]
        public IActionResult GetEmprendedores(int id)
        {
            var response = new ApiResponse();
            try
            {
                var result = _emprendedorService.GetEmprendedores().Where( x=>x.IdCategoria==id);
                var resultDto = _mapper.Map<IEnumerable<EmprendedorDto>>(result);

                
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
        public IActionResult GetEmprendedores()
        {
            var response = new ApiResponse();
            try
            {
                var result = _emprendedorService.GetEmprendedores();
                var resultDto = _mapper.Map<IEnumerable<EmprendedorDto>>(result);
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
        public async Task<IActionResult> GetEmprendedor(int id)
        {
            var response = new ApiResponse();
            try
            {
              
                var result = await _emprendedorService.GetEmprendedor(id);
                var resultDto = _mapper.Map<EmprendedorDto>(result);


                var rPersona = await _personaService.GetPersona(resultDto.IdPersona);
                var rDtoPersona = _mapper.Map<PersonaDto>(rPersona);

                var rEmpRed =  _emprendedorRedSocialService.GetEmprendedorRedSociales().Where(x=>x.IdEmprendedor==id) ;
                var resultRed = _mapper.Map<IEnumerable<EmprendedorRedSocialDto>>(rEmpRed);

                foreach (var item in resultRed)
                {
                    var rEmpSocial = await _redSocialService.GetRedSocial(item.IdRedSocial);
                    var resultSocial = _mapper.Map<RedSocialDto>(rEmpSocial);
                    item.Nombre = resultSocial.Nombre;
                    item.Logo = resultSocial.Logo;

                }
                var data = new {
                    emprendedor= resultDto,
                    persona = rDtoPersona,
                    social = resultRed
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

        [HttpPut]
        public async Task<IActionResult> PutEmprendedor(Emprendedor emprendedor)
        {
            var response = new ApiResponse();
            try
            {
                var oEmprendedor = _mapper.Map<Emprendedor>(emprendedor);
                bool result = await _emprendedorService.PutEmprendedor(oEmprendedor);

                foreach (var item in oEmprendedor.EmprendedorRedSocial)
                {
                     var oEmprendedorRedSocial = _mapper.Map<EmprendedorRedSocial>(item);
                     await _emprendedorRedSocialService.PutEmprendedorRedSocial(oEmprendedorRedSocial);
                }

                response.Exito = 1;
                response.Data = true;
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
            }
            return Ok(response);

        }
    }
}