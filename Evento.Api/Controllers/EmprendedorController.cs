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
        private readonly IMapper _mapper;

        public EmprendedorController(IEmprendedorService emprendedorService, IMapper mapper)
        {
            _emprendedorService = emprendedorService;
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
                response.Exito = 1;
                response.Data = resultDto;
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
                response.Exito = 1;
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