﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
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
using Microsoft.IdentityModel.Tokens;

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
        private readonly IRedSocialService _redSocialService;
        private readonly IEmprendedorRedSocialService _emprendedorRedSocialService;

        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AccountController(IPersonaService personaService, 
                                 IUsuarioService usuarioService, 
                                 ICongresoUsuarioService congresoUsuarioService, 
                                 IUsuarioRolService usuarioRolService, 
                                 IMapper mapper,
                                 IConfiguration configuration)
        {
            _personaService = personaService;
            _usuarioService = usuarioService;
            _congresoUsuarioService = congresoUsuarioService;
            _usuarioRolService = usuarioRolService;
            _emprendedorService = emprendedorService;
            _redSocialService = redSocialService;
            _emprendedorRedSocialService = emprendedorRedSocialService;

            _mapper = mapper;
            _configuration = configuration;
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
            else if (!RegexUtilities.IsValidEmail(personaUsuarioDto.Email))
            {
                response.Mensaje = "El formato del correo electrónico no es el correcto.";
                response.Data = false;
            }
            else
            {
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
                        var pPersona = _personaService.GetPersonas().FirstOrDefault(q => q.Id == oUsuario.IdPersona);
                        var personaUsuarioDto = _mapper.Map<PersonaUsuarioDto>(pPersona);
                        var oUsuRol = _usuarioRolService.GetUsuarioRoles().FirstOrDefault(q => q.IdUsuario == oUsuario.Id);
                        personaUsuarioDto.Email = oUsuario.Email;
                        personaUsuarioDto.IdRol = oUsuRol.IdRol;
                        var token = GenerateToken(personaUsuarioDto);
                        UserResponse userResponse = new UserResponse();
                        userResponse.Email = oUsuario.Email;
                        userResponse.Token = token;
                        response.Exito = 1;
                        response.Data = userResponse;
                    }
                    else
                    {
                        response.Exito = 0;
                        response.Mensaje = "Usuario o Password Incorrectos";
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
                        Latitud = "-21.535132",
                        Longitud = "-64.728431",
                        IdCategoria = 1,
                        NombreEmprendimiento = "Escribir nombre de emprendimiento",
                        Ubicacion = "Escribir Ubicacion",
                        //Estado = false
                    };

                    await _emprendedorService.PostEmprendedor(oEmprendedor);

                    var result = _redSocialService.GetRedSociales();
                    var resultDto = _mapper.Map<IEnumerable<RedSocialDto>>(result);

                    foreach (var item in resultDto)
                    {
                        var e = new EmprendedorRedSocial
                        {
                            IdEmprendedor = oEmprendedor.Id,
                            IdRedSocial = item.Id,
                            Direccion = ""

                        };
                        var oEmprendedorRedSocial = _mapper.Map<EmprendedorRedSocial>(e);
                        await _emprendedorRedSocialService.PostEmprendedorRedSocial(oEmprendedorRedSocial);
                    }
                   

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


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var response = new ApiResponse();
            try
            {
                var result = await _usuarioService.GetUsuario(id);
                var resultDto = _mapper.Map<UsuarioDto>(result);

                var resultRol =  _usuarioRolService.GetUsuarioRoles().Where(x=>x.IdUsuario==id);
                var resultRolDto = _mapper.Map<UsuarioRolDto>(resultRol.FirstOrDefault());

                var resultCongreso = _congresoUsuarioService.GetCongresoUsuarios().Where(x => x.IdUsuario == id);
                var resultCongresoDto = _mapper.Map<CongresoUsuarioDto>(resultCongreso.FirstOrDefault());

                var rPersona = await _personaService.GetPersona(resultDto.IdPersona);
                var rDtoPersona = _mapper.Map<PersonaDto>(rPersona);
               // var rDtoPersona = _mapper.Map<PersonaUsuarioDto>(rPersona);


                var data = new {
                    usuario=resultDto,
                    rol=resultRolDto,
                    congreso = resultCongresoDto, 
                    persona=rDtoPersona 
                };

     /*           rDtoPersona.IdPersona = rPersona.Id;
                rDtoPersona.IdUsuario = resultDto.Id;
                rDtoPersona.Email = resultDto.Email;
                rDtoPersona.IdCongreso = resultDto.IdCongreso;
                rDtoPersona.IdRol = resultRolDto.IdRol;
                rDtoPersona.IdCongreso = resultCongresoDto.IdCongreso;*/

    
                response.Exito = 1;
                response.Data = data;
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }



        private async Task<ApiResponse> ActualizarUsuario(PersonaUsuarioDto personaUsuarioDto, ApiResponse response)
        {
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var oPersona = _mapper.Map<Persona>(personaUsuarioDto);
                    await _personaService.PutPersona(oPersona);

                    var oUsuario = _mapper.Map<Usuario>(personaUsuarioDto);
                    oUsuario.IdPersona = oPersona.Id;
                    await _usuarioService.PutUsuario(oUsuario);

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
                        Latitud = "-21.535132",
                        Longitud = "-64.728431",
                        IdCategoria = 1,
                        NombreEmprendimiento = "Escribir nombre de emprendimiento",
                        Ubicacion = "Escribir Ubicacion",
                        //Estado = false
                    };

                    await _emprendedorService.PostEmprendedor(oEmprendedor);

                    var result = _redSocialService.GetRedSociales();
                    var resultDto = _mapper.Map<IEnumerable<RedSocialDto>>(result);

                    foreach (var item in resultDto)
                    {
                        var e = new EmprendedorRedSocial
                        {
                            IdEmprendedor = oEmprendedor.Id,
                            IdRedSocial = item.Id,
                            Direccion = ""

                        };
                        var oEmprendedorRedSocial = _mapper.Map<EmprendedorRedSocial>(e);
                        await _emprendedorRedSocialService.PostEmprendedorRedSocial(oEmprendedorRedSocial);
                    }


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

        private string GenerateToken(PersonaUsuarioDto personaUsuario)
        {
            // Leemos el secret_key desde nuestro appseting
            var secretKey = _configuration["Authentication:SecretKey"];                        
            //Header
            var symetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {
                 new Claim(ClaimTypes.Name, string.Concat(personaUsuario.Nombres," ", personaUsuario.Paterno, " ", personaUsuario.Materno)),
                 new Claim(ClaimTypes.Email, personaUsuario.Email),
                 new Claim(ClaimTypes.Role, personaUsuario.IdRol.ToString())
            };

            //Payload Issuer y Audience no definido
            var payload = new JwtPayload("", "", claims, DateTime.Now, DateTime.UtcNow.AddMinutes(5)
                );

            ////generar
            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
