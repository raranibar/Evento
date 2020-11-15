using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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


namespace Evento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IPersonaService _personaService;
        private readonly IUsuarioService _usuarioService;
        private readonly ICongresoUsuarioService _congresoUsuarioService;
        private readonly IUsuarioRolService _usuarioRolService;
        private readonly IMapper _mapper;

        public AccountController(IPersonaService personaService, IUsuarioService usuarioService, ICongresoUsuarioService congresoUsuarioService, IUsuarioRolService usuarioRolService, IMapper mapper)
        {
            _personaService = personaService;
            _usuarioService = usuarioService;
            _congresoUsuarioService = congresoUsuarioService;
            _usuarioRolService = usuarioRolService;
            _mapper = mapper;
        }

        // Post api/Account/Register
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> PostRegister(PersonaUsuarioDto personaUsuarioDto)
        {

            var oPersona = _mapper.Map<Persona>(personaUsuarioDto);
            await _personaService.PostPersona(oPersona);
            var oUsuario = _mapper.Map<Usuario>(personaUsuarioDto);
            oUsuario.IdPersona = oPersona.Id;
            await _usuarioService.PostUsuario(oUsuario);
            var oCongresoUsuario = _mapper.Map<CongresoUsuario>(personaUsuarioDto);
            oCongresoUsuario.IdCongreso = oUsuario.IdCongreso;
            oCongresoUsuario.IdUsuario = oUsuario.Id;
            await _congresoUsuarioService.PostCongresoUsuario(oCongresoUsuario);
            var oUsuarioRol = _mapper.Map<UsuarioRol>(personaUsuarioDto);
            oUsuarioRol.IdUsuario = oUsuario.Id;
            await _usuarioRolService.PostUsuarioRol(oUsuarioRol);

            var response = new ApiResponse<bool>(true);
           
            return Ok(response);

        }

        [HttpPost]
        [Route("Verify")]
        public ActionResult PostVerify(LoginDto loginDto)
        {
            var oUsuario = _usuarioService.GetUsuarios().FirstOrDefault(q => q.Email == loginDto.Login && q.Estado == true);
            if (oUsuario != null)
            {
                if (PasswordHasher.ValidatePassword(loginDto.Password, oUsuario.Clave, oUsuario.ClaveSalt))
                    return Ok(true);
                else
                    return BadRequest(false);
            }
            
            return BadRequest(false);
            
        
        }
    }
}
