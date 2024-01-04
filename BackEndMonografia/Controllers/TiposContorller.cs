using BackEndMonografia.Services;
using Microsoft.AspNetCore.Mvc;
using BackEndMonografia.Models;
using BackEndMonografia.Services.Interfaces;
using BackEndMonografia.Dtos;

namespace BackEndMonografia.Controllers
{
    [ApiController]
    [Route("v1/tipos")]
    public class TiposContorller : ControllerBase
    {
        public ITypeService _typeService;
        public IBaseService<TipoDto> _baseService;

        public TiposContorller(ITypeService typeService, IBaseService<TipoDto> baseService)
        {
            _typeService = typeService;
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Type>>> ObterTodos()
        {
            var retorno =  await _baseService.ObterTodos();

            return Ok(retorno.ToList());
        }

        [HttpPost]
        public async Task<ActionResult<int>> Adicionar([FromBody] TipoDto model)
        {
            var retorno = await _baseService.Adicionar(model);

            return Ok(retorno);
        }
    }
}
