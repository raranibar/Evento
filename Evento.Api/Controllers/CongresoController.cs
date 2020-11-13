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
    public class CongresoController : ControllerBase
    {
        private readonly ICongresoService _congresoService;
        private readonly IMapper _mapper;

        public CongresoController(ICongresoService congresoService, IMapper mapper)
        {
            _congresoService = congresoService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCongresos()
        {
            var response = new ApiResponse();
            try
            {
                var result = _congresoService.GetCongresos();
                var resultDto = _mapper.Map<IEnumerable<CongresoDto>>(result);
                response.Exito = 1;
                response.Data = resultDto;
            }
            catch(Exception ex)
            {
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCongreso(int id)
        {
            var response = new ApiResponse();
            try
            {
                var result = await _congresoService.GetCongreso(id);
                var resultDto = _mapper.Map<CongresoDto>(result);
                response.Exito = 1;
                response.Data = resultDto;
            }
            catch (Exception ex) {
                response.Mensaje = ex.Message;
            }            
            return Ok(response);
        }
   

        [HttpPost]
        public async Task<IActionResult> PostCongreso(CongresoDto CongresoDto)
        {
            var response = new ApiResponse();
            try
            {
                var oCongreso = _mapper.Map<Congreso>(CongresoDto);
                await _congresoService.PostCongreso(oCongreso);
                CongresoDto = _mapper.Map<CongresoDto>(oCongreso);

                response.Exito = 1;
                response.Data = CongresoDto;                
            }catch (Exception ex)
            {
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCongreso(CongresoDto CongresoDto, int id)
        {
            var response = new ApiResponse();
            try
            {
                var oCongreso = _mapper.Map<Congreso>(CongresoDto);
                bool result = await _congresoService.PutCongreso(oCongreso);
                response.Exito = 1;
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
            }
            return Ok(response);            

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCongreso(int id)
        {
            var response = new ApiResponse();
            try
            {
                bool result = await this._congresoService.DeleteCongreso(id);
                response.Exito = 1;
                response.Data =result;
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
            }
            return Ok(response);            
        }
    }
}
