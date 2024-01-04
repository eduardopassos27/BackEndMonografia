using BackEndMonografia.Services;
using Microsoft.AspNetCore.Mvc;
using BackEndMonografia.Models;
using BackEndMonografia.Services.Interfaces;
using BackEndMonografia.Dtos;

namespace BackEndMonografia.Controllers
{
    [ApiController]
    [Route("v1/types")]
    public class TypeController : ControllerBase
    {
        public ITypeService _typeService;
        public IBaseService<TipoDto> _baseService;

        public TypeController(ITypeService typeService, IBaseService<TipoDto> baseService)
        {
            _typeService = typeService;
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Type>>> GetAllTypes()
        {
            var retorno =  await _baseService.GetAll();

            return Ok(retorno.ToList());
        }

        [HttpPost]
        public async Task<ActionResult<int>> InsertType([FromBody] TipoDto model)
        {
            var retorno = await _baseService.Add(model);

            return Ok(retorno);
        }
    }
}
