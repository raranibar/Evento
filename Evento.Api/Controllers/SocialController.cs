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
    public class SocialController : ControllerBase
    {
        private readonly IRedSocialService _redSocialService;
        private readonly IMapper _mapper;

        public SocialController(IRedSocialService redSocialService, IMapper mapper)
        {
            _redSocialService = redSocialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetRedSocial()
        {
            var response = new ApiResponse();
            try
            {
                var result = _redSocialService.GetRedSociales();
                var resultDto = _mapper.Map<IEnumerable<RedSocialDto>>(result);
                response.Exito = 1;
                response.Data = resultDto;
            }
            catch (Exception ex)
            {
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }
    }
}