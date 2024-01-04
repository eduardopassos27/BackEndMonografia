using BackEndMonografia.Dtos;
using BackEndMonografia.Models;
using BackEndMonografia.Services;
using BackEndMonografia.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEndMonografia.Controllers
{
    [ApiController]
    [Route("v1/status")]
    public class StatusController : ControllerBase
    {
        private readonly IBaseService<StatusDto> _baseService;

        public StatusController(IBaseService<StatusDto> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<StatusDto>>> ObterTodos()
        {
            var retorno = await _baseService.ObterTodos();

            return Ok(retorno.ToList());
        }
        [HttpPost]
        public async Task<ActionResult<int>> Adicionar([FromBody] StatusDto model)
        {
            var retorno = await _baseService.Adicionar(model);

            return Ok(retorno);
        }
    }
}
