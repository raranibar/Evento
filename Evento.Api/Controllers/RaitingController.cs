using AutoMapper;
using Evento.Api.Response;
using Evento.Core.DTO;
using Evento.Core.Entities;
using Evento.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
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

        [Route("data")]
        public IActionResult GetEmprendedorRaiting(int id)
        {
            var response = new ApiResponse();
            try
            {
                var result = _raitingService.GetRaitings().Where(x => x.IdEmprendedor == id);

                double suma = 0;

                foreach (var item in result)
                {
                    suma += item.Rating;
                }


                var result1 = _raitingService.TotalRaiting();
                var result2 = _raitingService.RaitingEmprendedor(id);

                double punt = suma / result.Count();
                var data = new {

                    votos = result.Count(),
                    suma = suma,
                    puntaje = (punt.ToString().Length>1)?punt.ToString().Substring(0,3):punt.ToString(),
                    total = result1,
                    cantidad= result2
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
