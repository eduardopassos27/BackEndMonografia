using BackEndMonografia.Dtos;
using BackEndMonografia.Models;
using BackEndMonografia.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEndMonografia.Controllers
{
    [ApiController]
    [Route("v1/origens")]
    public class OrigensController : ControllerBase
    {
        private readonly IBaseService<OrigemDto> _baseService;

        public OrigensController(IBaseService<OrigemDto> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrigemDto>>> GetAll() 
        {
            var result = await _baseService.ObterTodos();

            return Ok(result.ToList());
        }

        [HttpPost]
        public async Task<ActionResult<List<OrigemDto>>> Adicionar(OrigemDto model)
        {
            var result = await _baseService.Adicionar(model);

            return Ok(result);
        }
    }
}
