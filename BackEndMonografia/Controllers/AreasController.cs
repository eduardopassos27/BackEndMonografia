using BackEndMonografia.Models;
using BackEndMonografia.Models.System;
using BackEndMonografia.Services;
using BackEndMonografia.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEndMonografia.Controllers
{
    [ApiController]
    [Route("v1/areas")]
    public class AreasController : ControllerBase
    {
        private readonly IBaseService<AreaDto> _baseService;

        public AreasController(IBaseService<AreaDto> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        ///
        public async Task<ActionResult<List<AreaDto>>> ObterTodasAreas()
        {
            var retorno = await _baseService.ObterTodos();

            return Ok(retorno.ToList());
        }
        [HttpPost]
        public async Task<ActionResult<int>> AdicionarArea([FromBody] AreaDto model)
        {
            var retorno = await _baseService.Adicionar(model);

            return Ok(retorno);
        }
    }
}
