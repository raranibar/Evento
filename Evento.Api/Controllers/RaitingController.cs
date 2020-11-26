using AutoMapper;
using Evento.Api.Response;
using Evento.Core.DTO;
using Evento.Core.Entities;
using Evento.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Transactions;

namespace Evento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaitingController : ControllerBase
    {
        private readonly IRaitingService _raitingService;
        private readonly IMapper _mapper;

        public RaitingController(IRaitingService raitingService, IMapper mapper)
        {
            _raitingService = raitingService;
            _mapper = mapper;
        }

        [HttpGet("{IdEmprendedor}")]
        public IActionResult Get(int IdEmprendedor)
        {
            var response = new ApiResponse();
            try
            {
                var result = _raitingService.RaitingEmprendedor(IdEmprendedor);
                var resultDto = _mapper.Map<RaitingDto>(result);
                response.Exito = 1;
                response.Data = resultDto;
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("TotalRaiting")]
        public IActionResult GetTotalRaiting()
        {
            var response = new ApiResponse();
            try
            {
                var result = _raitingService.TotalRaiting();
                
                response.Exito = 1;
                
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("{IdEmprendedor}")]
        [Route("EmprendedorRaiting")]
        public IActionResult GetEmprendedorRaiting(int IdEmprendedor)
        {
            var response = new ApiResponse();
            try
            {
                var result = _raitingService.VotosEmprendedor(IdEmprendedor);

                response.Exito = 1;

                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostRaiting(RaitingDto raitingDto)
        {
            var response = new ApiResponse();
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var oRaiting = _mapper.Map<Raiting>(raitingDto);
                    await _raitingService.PostRaiting(oRaiting);
                    raitingDto = _mapper.Map<RaitingDto>(oRaiting);

                    response.Exito = 1;
                    response.Data = raitingDto;
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    response.Mensaje = ex.Message;
                }
            }

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRaiting(RaitingDto raitingDto, int id)
        {
            var response = new ApiResponse();
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var oRaiting = _mapper.Map<Raiting>(raitingDto);
                    bool result = await _raitingService.PutRaiting(oRaiting);
                    response.Exito = 1;
                    response.Data = result;
                }
                catch (Exception ex)
                {
                    response.Mensaje = ex.Message;
                }
            }
            return Ok(response);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRaiting(int id)
        {
            var response = new ApiResponse();
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    bool result = await this._raitingService.DeleteRaiting(id);
                    response.Exito = 1;
                    response.Data = result;
                }
                catch (Exception ex)
                {
                    response.Mensaje = ex.Message;
                }
            }
            return Ok(response);
        }
    }
}
