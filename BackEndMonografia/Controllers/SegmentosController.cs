using BackEndMonografia.Dtos;
using BackEndMonografia.Models;
using BackEndMonografia.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEndMonografia.Controllers
{
    [ApiController]
    [Route("v1/segmentos")]
    public class SegmentosController : ControllerBase
    {
        private readonly IBaseService<SegmentoDto> _baseService;

        public SegmentosController(IBaseService<SegmentoDto> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SegmentoDto>>> ObterTodos()
        {
            var retorno = await _baseService.ObterTodos();

            return Ok(retorno.ToList());
        }

        [HttpPost]
        public async Task<ActionResult<int>> Adicionar([FromBody] SegmentoDto model)
        {
            var retorno = await _baseService.Adicionar(model);

            return Ok(retorno);
        }
    }
}
