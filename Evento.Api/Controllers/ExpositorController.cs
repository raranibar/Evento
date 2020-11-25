using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using Evento.Api.Response;
using Evento.Core.DTO;
using Evento.Core.Entities;
using Evento.Core.Helper;
using Evento.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Evento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpositorController : ControllerBase
    {

        private readonly IPersonaService _personaService;
        private readonly IExpositorService _expositorService;
        private readonly IUsuarioService _usuarioService;
        private readonly ICongresoUsuarioService _congresoUsuarioService;
        private readonly IUsuarioRolService _usuarioRolService;
        private readonly IvPersonaExpositorService _vPersonaExpositorService;
        private readonly IConfiguration _configuration;

        private readonly IMapper _mapper;

        public ExpositorController(
            IPersonaService personaService, IExpositorService expositorService,
            IUsuarioService usuarioService, ICongresoUsuarioService congresoUsuarioService,
            IUsuarioRolService usuarioRolService, IConfiguration configuration,
            IvPersonaExpositorService vPersonaExpositorService, IMapper mapper)
        {
            _personaService = personaService;
            _expositorService = expositorService;
            _usuarioService = usuarioService;
            _congresoUsuarioService = congresoUsuarioService;
            _usuarioRolService = usuarioRolService;
            _vPersonaExpositorService = vPersonaExpositorService;
            _mapper = mapper;

            _configuration = configuration;
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

 /*       [HttpGet]
        [Route("eje")]
        public IActionResult GetExpositoresByEje(int id)
        {
            var response = new ApiResponse();
            try
            {
                var result = _expositorService.GetExpositores().Where(x => x.IdEjeTematico == id);
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
        */

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpositor(int id)
        {
            var response = new ApiResponse();
            try
            {
                var rExpositor = await _expositorService.GetExpositor(id);
                var expositorDto = _mapper.Map<ExpositorDto>(rExpositor);

                var rPersona = await _personaService.GetPersona(expositorDto.IdPersona);
                var personaDto = _mapper.Map<PersonaDto>(rPersona);

                var rUsuario = _usuarioService.GetUsuarios().Where(x => x.IdPersona == rPersona.Id).ToList();

                var cUser = new
                {
                    email = "",
                    id = 0
                };

                if (rUsuario.Count != 0)
                {
                    var usuarioDto = _mapper.Map<UsuarioDto>(rUsuario[0]);
                    cUser = new
                    {
                        email = usuarioDto.Email,
                        id = usuarioDto.Id
                    };
                }

                var data = new
                {
                    usuario = cUser,
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


        [HttpGet]
        [Route("eje")]
        public IActionResult GetPersonaExpositor(int id)
        {
            var response = new ApiResponse();
            try
            {
                var result = _vPersonaExpositorService.GevPersonaExpositors().Where(x=>x.IdEjeTematico==id);
                var resultDto = _mapper.Map<IEnumerable<vPersonaExpositorDto>>(result);

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
        [Route("personaexpositor")]
        public IActionResult GetPersonaExpositorByEje()
        {
            var response = new ApiResponse();
            try
            {
                var result = _vPersonaExpositorService.GevPersonaExpositors();
                var resultDto = _mapper.Map<IEnumerable<vPersonaExpositorDto>>(result);

                response.Exito = 1;
                response.Data = resultDto;
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
                    var Nombre = String.Concat(oPersona.Nombres, " ", oPersona.Paterno);
                    await _personaService.PostPersona(oPersona);

                    if (RegexUtilities.IsValidEmail(expositorPersonaDto.Email))
                    {
                        var lUsuario = _usuarioService.GetUsuarios().Where(x => x.IdPersona==oPersona.Id).ToList();
                        if (lUsuario.Count() == 0)
                        {
                            var oUsuario = _mapper.Map<Usuario>(expositorPersonaDto);
                            oUsuario.IdPersona = oPersona.Id;
                            string GeneraClave = PasswordHasher.GenerarPassword(5);
                            oUsuario.Clave = GeneraClave;
                            await _usuarioService.PostUsuario(oUsuario);

                            var oCongresoUsuario = _mapper.Map<CongresoUsuario>(expositorPersonaDto);
                            oCongresoUsuario.IdCongreso = oUsuario.IdCongreso;
                            oCongresoUsuario.IdUsuario = oUsuario.Id;
                            await _congresoUsuarioService.PostCongresoUsuario(oCongresoUsuario);


                            var oUsuarioRol = _mapper.Map<UsuarioRol>(expositorPersonaDto);
                            oUsuarioRol.IdUsuario = oUsuario.Id;
                            await _usuarioRolService.PostUsuarioRol(oUsuarioRol);


                            var oExpositor = _mapper.Map<Expositor>(expositorPersonaDto);
                            oExpositor.IdPersona = oPersona.Id;
                            await _expositorService.PostExpositor(oExpositor);

                            var idExp = _expositorService.GetExpositores().Where(x => x.IdPersona == oPersona.Id).ToList();
                            var oIdExp = _mapper.Map<ExpositorDto>(idExp[0]);

                            SendByEMail.SendEmailUsuario(Nombre, oUsuario.Email, GeneraClave, _configuration);

                            response.Exito = 1;
                            response.Data = oIdExp.Id;
                            response.Mensaje = "Expositor registrado correctamente";
                            transaction.Complete();
                        }
                    }
                    else
                    {
                        response.Exito = 0;
                        response.Data = false;
                        response.Mensaje = "Debe ingresar un email valido";
                    }
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