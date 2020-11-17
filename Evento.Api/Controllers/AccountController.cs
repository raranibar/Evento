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

        private readonly IEmprendedorService _emprendedorService;



        private readonly IMapper _mapper;

        public AccountController(IPersonaService personaService, IUsuarioService usuarioService,
            ICongresoUsuarioService congresoUsuarioService, IUsuarioRolService usuarioRolService,
            IEmprendedorService emprendedorService,
            IMapper mapper)
        {
            _personaService = personaService;
            _usuarioService = usuarioService;
            _congresoUsuarioService = congresoUsuarioService;
            _usuarioRolService = usuarioRolService;
            _emprendedorService = emprendedorService;

            _mapper = mapper;
        }

        // Post api/Account/Register
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> PostRegister(PersonaUsuarioDto personaUsuarioDto)
        {
            var response = new ApiResponse();
            var personaDocNum = _personaService.GetPersonas().Where(
                q => q.Estado == true &&
                q.NumDocumento == personaUsuarioDto.NumDocumento &&
                q.IdTipoDocumento == personaUsuarioDto.IdTipoDocumento
            ).FirstOrDefault();
            var usuario = _usuarioService.GetUsuarios().Where(
                q => q.Estado == true && q.Email == personaUsuarioDto.Email
                ).FirstOrDefault();
            if (personaDocNum != null)
            {
                response.Mensaje = "El tipo de documento y el número ya estan Registrados.";
                response.Data = false;
            }
            else if (usuario != null)
            {
                response.Mensaje += " El email ya esta registrado.";
                response.Data = false;
            }
            else
            {
                response.Mensaje = "Usuario agregado correctamente";
                response.Exito = 1;
                response = await RegistroUsuario(personaUsuarioDto, response);
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("Verify")]
        public ActionResult PostVerify(LoginDto loginDto)
        {
            var response = new ApiResponse();
            try
            {
                var oUsuario = _usuarioService.GetUsuarios().FirstOrDefault(q => q.Email == loginDto.Login && q.Estado == true);
                if (oUsuario != null)
                {
                    if (PasswordHasher.ValidatePassword(loginDto.Password, oUsuario.Clave, oUsuario.ClaveSalt))
                    {
                        response.Exito = 1;
                        response.Data = true;
                    }
                    else
                    {
                        response.Exito = 0;
                        response.Mensaje = "Usuario y Password Incorrectos";
                        response.Data = false;
                    }
                }
                else
                {
                    response.Exito = 0;
                    response.Mensaje = "Usuario No registrados";
                    response.Data = false;
                }

            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        private async Task<ApiResponse> RegistroUsuario(PersonaUsuarioDto personaUsuarioDto, ApiResponse response)
        {
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
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


                    var oEmprendedor = _mapper.Map<Emprendedor>(personaUsuarioDto);

                    oEmprendedor = new Emprendedor
                    {
                        IdPersona = oPersona.Id,
                        Descripcion = "Escribir descripcion",
                        Latitud = "lat",
                        Longitud = "lng",
                        IdCategoria = 1,
                        NombreEmprendimiento = "Escribir nombre de emprendimiento",
                        Ubicacion = "Escribir Ubicacion"
                    };

                    await _emprendedorService.PostEmprendedor(oEmprendedor);

                    response.Exito = 1;
                    response.Data = true;
                    transaction.Complete();
                }
                catch (TransactionException ex)
                {
                    response.Mensaje = String.Format(" {0} - {1}", ex.Message, ex.InnerException);
                }
                return response;
            }
        }

    }
}
