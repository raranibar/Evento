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
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioService _comentarioService;
        private readonly IMapper _mapper;

        public ComentarioController(IComentarioService comentarioService, IMapper mapper)
        {
            _comentarioService = comentarioService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetComentario(int id)
        {
            var response = new ApiResponse();
            try
            {
                var result = _comentarioService.GetComentarios().Where(x=>x.IdEmprendedor==id);
                var resultDto = _mapper.Map<IEnumerable<ComentarioDto>>(result);
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
        public async Task<IActionResult> PostComentario(ComentarioDto comentariodto)
        {
            var response = new ApiResponse();
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var oComentario = _mapper.Map<Comentario>(comentariodto);
                    oComentario.Estado = true;
                    await _comentarioService.PostComentario(oComentario);

                    response.Exito = 1;
                    response.Data = "Comentario registrado";
                    transaction.Complete();
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